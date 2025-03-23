using idsp2025_jared_green.Controllers;
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
    public partial class frmFulfillOrder : Form
    {
        private dtoOrders _orderDetails;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly int _employeeID;

        //public frmFulfillOrder(int txnID, ITransactionController transactionController)
        public frmFulfillOrder(ITransactionController transactionController, IInventoryController inventoryController, int employeeID)
        {
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _employeeID = employeeID;
            InitializeComponent();
        }



        private async void btnExitFulfillment_Click(object sender, EventArgs e)
        {
            await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employeeID, "RECEIVED");
            this.Close();
        }

        private async void frmFulfillOrder_Load(object sender, EventArgs e)
        {

            _orderDetails = this.Tag as dtoOrders;
            if (_orderDetails != null)
            {
                await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employeeID, "ASSEMBLING");
                lblOrderID.Text = _orderDetails.txnID.ToString();
                BindingList<dtoOrderItem> txnItems = await _transactionController.GetTxnItems(_orderDetails.txnID);
                RefreshDataGridView(dgvTransactionItems, bsOrderFulfillment, txnItems);

                // Add the tracking column:
                DataGridViewCheckBoxColumn dgvCbc = new DataGridViewCheckBoxColumn();
                dgvCbc.ValueType = typeof(bool);
                dgvCbc.Name = "fulfilled";
                dgvCbc.HeaderText = "Fulfilled";
                dgvTransactionItems.Columns.Add(dgvCbc);
            } else
            {
                MessageBox.Show("There was an error accessing the order's items. Please contact a system administrator", "Please contact a system administrator");
                this.Close();
            }
            // _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employeeID, "ASSEMBLING");
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
            int totalItems = dgvTransactionItems.Rows.Count;
            // Must cast the collection of rows into an enumerable collection. Then can use LINQ methods to query the rows.
            int itemsFulfilled = dgvTransactionItems.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells["Fulfilled"].Value));
            // Progress bar value is an int...

            pgbOrderFulfillment.Value = (itemsFulfilled * 100) / totalItems;
        }

        private void dgvTransactionItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex == dgvTransactionItems.Columns.IndexOf(dgvTransactionItems.Columns["Fulfilled"]))
            {
                int row = e.RowIndex;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvTransactionItems.Rows[row].Cells[e.ColumnIndex];
                bool isChecked = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !isChecked;
                UpdateProgressBar();
            }
        }

        private async void btnMarkOrderFulfilled_Click(object sender, EventArgs e)
        {

            if (pgbOrderFulfillment.Value == pgbOrderFulfillment.Maximum)
            {
                try
                {
                    BindingList<dtoOrderItem> items = await _transactionController.GetTxnItems(_orderDetails.txnID);

                    foreach (dtoOrderItem item in items)
                    {   
                        // Move the inventory -> Site 2 to Site 3
                        await _inventoryController.MoveInventory(2, 3, item.quantityRequested, item.itemID, "0", _orderDetails.txnID.ToString());
                    }
                    // Replace the hard-coded employeeID with the id of the logged in employee.
                    await _transactionController.UpdateTransactionStatus(_orderDetails.txnID, _employeeID, "ASSEMBLED");
                    this.Close();
                }
                catch (Exception ex)
                {
                    return;
                }
            } else
            {
                MessageBox.Show("Please fulfill all items in the order before submitting.", "Order Fulfillment Incomplete");
            }
        }
    }
}


