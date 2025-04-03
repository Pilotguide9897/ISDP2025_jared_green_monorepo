using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
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
    public partial class frmPrepareOnlineOrder : Form
    {
        private dtoOrders _orderDetails;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly ILocationController _locationController;
        private readonly Employee _employee;

        public frmPrepareOnlineOrder(ITransactionController transactionController, IInventoryController inventoryController, ILocationController locationController, Employee employee)
        {
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _locationController = locationController;
            _employee = employee;
            InitializeComponent();
        }

        private async void btnCancelPrepareOrder_Click(object sender, EventArgs e)
        {
            await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "RECEIVED");
            this.Close();
        }

        private async void btnMarkOrderPrepared_Click(object sender, EventArgs e)
        {
            if (pgbOnlineOrderProgress.Value == pgbOnlineOrderProgress.Maximum)
            {
                try
                {
                    BindingList<Site> bullseyeLocations = await _locationController.GetBullseyeLocations();
                    Site site = (from loc in bullseyeLocations where loc.SiteName == _orderDetails.siteName select loc).FirstOrDefault();
                    if (site != null)
                    {
                        BindingList<dtoOrderItem> items = await _transactionController.GetTxnItems(_orderDetails.txnID);

                        foreach (dtoOrderItem item in items)
                        {
                            // Move the inventory 
                            await _inventoryController.MoveInventory(site.SiteId, 10000, item.quantityRequested, item.itemID, "0", _orderDetails.txnID.ToString());
                        }
                        //await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "PREPARED");
                        await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "READY");

                        this.Close();
                    }
                    else
                    {
                        await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "RECEIVED");
                        MessageBox.Show("Unable to gather store data for preparing order.", "Site Data Error");
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fulfill all items in the order before marking prepared.", "Order Preparation Incomplete");
            }
        }

        private async void dgvPrepareOnlineOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex == dgvPrepareOnlineOrder.Columns.IndexOf(dgvPrepareOnlineOrder.Columns["Fulfilled"]))
            {
                int row = e.RowIndex;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvPrepareOnlineOrder.Rows[row].Cells[e.ColumnIndex];
                bool isChecked = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !isChecked;
                UpdateProgressBar();
            }
        }

        private async void frmPrepareOnlineOrder_Load(object sender, EventArgs e)
        {
            _orderDetails = this.Tag as dtoOrders;
            if (_orderDetails != null)
            {
                await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employee.EmployeeId, "PREPARING");
                lblOrderID.Text = _orderDetails.txnID.ToString();
                BindingList<dtoOrderItem> txnItems = await _transactionController.GetTxnItems(_orderDetails.txnID);
                RefreshDataGridView(dgvPrepareOnlineOrder, bsPrepareStoreOrder, txnItems);

                // Add the tracking column:
                DataGridViewCheckBoxColumn dgvCbc = new DataGridViewCheckBoxColumn();
                dgvCbc.ValueType = typeof(bool);
                dgvCbc.Name = "fulfilled";
                dgvCbc.HeaderText = "Fulfilled";
                dgvPrepareOnlineOrder.Columns.Add(dgvCbc);
            }
            else
            {
                MessageBox.Show("There was an error accessing the order's items. Please contact a system administrator", "Please contact a system administrator");
                this.Close();
            }
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

        public void UpdateProgressBar()
        {
            int totalItems = dgvPrepareOnlineOrder.Rows.Count;
            // Must cast the collection of rows into an enumerable collection. Then can use LINQ methods to query the rows.
            int itemsFulfilled = dgvPrepareOnlineOrder.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells["Fulfilled"].Value));

            pgbOnlineOrderProgress.Value = (itemsFulfilled * 100) / totalItems;
        }
    }
}
