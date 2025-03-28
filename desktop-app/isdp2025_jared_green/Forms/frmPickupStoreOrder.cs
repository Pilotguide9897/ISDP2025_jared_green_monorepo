using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Forms;
using idsp2025_jared_green.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idsp2025_jared_green.Forms
{
    public partial class frmPickupStoreOrder : Form
    {

        private bool _isDrawing = false;
        private Point _lastPoint;
        private Bitmap _signatureBitmap;
        private dtoOrders _orderDetails;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly ILocationController _locationController;
        private readonly Employee _employee;

        public frmPickupStoreOrder(ITransactionController transactionController, IInventoryController inventoryController, ILocationController locationController, Employee employee)
        {
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _locationController = locationController;
            _employee = employee;
            InitializeComponent();

            // Initialize Bitmap for drawing
            _signatureBitmap = new Bitmap(pnlDriverSignature.Width, pnlDriverSignature.Height);
            pnlDriverSignature.BackgroundImage = _signatureBitmap;
        }

        private async void btnAcceptOrderPickup_Click(object sender, EventArgs e)
        {
            bool allItemsPresent = true;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {

                var cellValue = row.Cells["fulfilled"].Value;

                if (cellValue == null || !(bool)cellValue)
                {
                    allItemsPresent = false;
                    break;
                }
            }

            if (allItemsPresent)
            {
                try
                {
                    BindingList<Site> bullseyeLocations = await _locationController.GetBullseyeLocations();
                    Site site = (from loc in bullseyeLocations where loc.SiteId == _employee.SiteId select loc).FirstOrDefault();

                    BindingList<dtoOrderItem> items = await _transactionController.GetTxnItems(_orderDetails.txnID);

                    foreach (dtoOrderItem item in items)
                    {

                        await _inventoryController.MoveInventory(site.SiteId, 9999, item.quantityRequested, item.itemID, "0", "On Truck");
                    }

                    await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "IN TRANSIT");
                    this.Close();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Some items are still unreceived.", "Error: Items Unreceived");
            }
        }

        private void btnExitStoreOrderPickup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetDriverSignature_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = Graphics.FromImage(_signatureBitmap))
            {
                graphics.Clear(Color.White);
                _isDrawing = false;
                _lastPoint = Point.Empty;
                pnlDriverSignature.Invalidate();
            }
        }

        private void pnlDriverSignature_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(_signatureBitmap))
                {
                    g.DrawLine(Pens.Black, _lastPoint, e.Location);
                }

                _lastPoint = e.Location;
                pnlDriverSignature.Invalidate();
            }
        }

        private void pnlDriverSignature_MouseDown(object sender, MouseEventArgs e)
        {
            _isDrawing = true;
            _lastPoint = e.Location;
        }

        private void pnlDriverSignature_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }


        private void RefreshDataGridView(DataGridView dgv, BindingSource bs, BindingList<dtoOrderItem> txnitems)
        {
            bs.Clear();
            bs.DataSource = txnitems;
            dgv.DataSource = null;
            dgv.DataSource = bs;
            dgv.Font = new Font("Arial", 9);

            // Rename the columns:
            dgv.Columns[0].HeaderText = "Item ID";
            dgv.Columns[1].HeaderText = "Product Name";
            dgv.Columns[2].HeaderText = "Quantity";
            dgv.Columns[3].HeaderText = "Fulfilled";

            // Remove unwanted column
            dgv.Columns.RemoveAt(3);

        }

        private async void frmPickupStoreOrder_Load(object sender, EventArgs e)
        {
            _orderDetails = this.Tag as dtoOrders;
            if (_orderDetails != null)
            {
                lblStoreOrderId.Text = _orderDetails.txnID.ToString();
                BindingList<dtoOrderItem> txnItems = await _transactionController.GetTxnItems(_orderDetails.txnID);
                RefreshDataGridView(dgvOrderItems, bsPickupOrder, txnItems);

                // Add the tracking column:
                DataGridViewCheckBoxColumn dgvCbc = new DataGridViewCheckBoxColumn();
                dgvCbc.ValueType = typeof(bool);
                dgvCbc.Name = "fulfilled";
                dgvCbc.HeaderText = "Received";
                dgvOrderItems.Columns.Add(dgvCbc);
            }
            else
            {
                MessageBox.Show("There was an error accessing the order's items. Please contact a system administrator", "Please contact a system administrator");
                this.Close();
            }
        }

        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex == dgvOrderItems.Columns.IndexOf(dgvOrderItems.Columns["Fulfilled"]))
            {
                int row = e.RowIndex;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvOrderItems.Rows[row].Cells[e.ColumnIndex];
                bool isChecked = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !isChecked;
            }
        }
    }
}