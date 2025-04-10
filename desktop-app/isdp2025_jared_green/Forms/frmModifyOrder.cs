using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Forms.CustomControls;
using idsp2025_jared_green.Helpers;
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
    public partial class frmModifyOrder : Form
    {
        private readonly IItemController _itemController;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private int _employeeID;
        private int _orderID;

        public frmModifyOrder(IItemController itemController, ITransactionController transactionController, IInventoryController inventoryController)
        {
            _transactionController = transactionController;
            _itemController = itemController;
            _inventoryController = inventoryController;

            InitializeComponent();
        }

        private async void frmModifyOrder_Load(object sender, EventArgs e)
        {
            _employeeID = (this.Tag as Txn).EmployeeId;
            _orderID = (this.Tag as Txn).TxnId;
            if ((this.Tag as Txn).TxnType == "Back Order")
            {
                lblOrderType.Text = "Back Order";
                dtpBackorderDate.Visible = true;
                dtpBackorderDate.Value = (this.Tag as Txn).ShipDate;
            }
            else
            {
                lblOrderType.Text = (this.Tag as Txn).EmergencyDelivery == 1 ? "Emergency" : "Standard";
            }
            lblOrderID.Text = _orderID.ToString();

            // Load Inventory
            BindingList<Item> items = await _itemController.GetAllItems();
            DataTable dt = DataTableConverter.ConvertToDataTable(items);
            bsBullseyeInventory.DataSource = dt;
            dgvBullseyeInventory.DataSource = bsBullseyeInventory;
            dgvBullseyeInventory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            bsBullseyeInventory.Filter = "Active = 1";

            // Remove unnecessary columns
            RemoveColumnsFromDGV(new List<string> { "Sku", "Weight", "CostPrice", "RetailPrice", "SupplierId", "Notes", "Active", "ImageLocation", "CategoryNavigation", "Inventories", "Supplier", "Txnitems", "ImagePaths" }, dgvBullseyeInventory);
            dgvBullseyeInventory.Columns["CaseSize"].Visible = false;
            dgvBullseyeInventory.AutoResizeColumns();

            // Load Existing Order Data
            BindingList<dtoOrderItem> orderItems = await _transactionController.GetTxnItems(_orderID);
            bsOrderItems.DataSource = orderItems;
            dgvOrderItems.DataSource = null;
            dgvOrderItems.AutoGenerateColumns = false; 
            dgvOrderItems.Columns.Clear();

            // Add Product Name Column
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product ID",
                DataPropertyName = "itemID",
                Name = "itemID",
                ReadOnly = true
            });


            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product Name",
                DataPropertyName = "productName",
                Name = "ProductName",
                ReadOnly = true
            });

            // Add Quantity Requested as a Numeric Column
            DataGridViewNumericUpDownColumn nudColumn = new DataGridViewNumericUpDownColumn
            {
                HeaderText = "Quantity Requested",
                Name = "QuantityRequested",
                DataPropertyName = "quantityRequested",
                Width = 150
            };
            dgvOrderItems.Columns.Add(nudColumn);

            dgvOrderItems.DataSource = bsOrderItems;

            bsOrderItems.ResetBindings(false);

            for (int i = 0; i < dgvOrderItems.Rows.Count; i++)
            {
                var oldCell = dgvOrderItems.Rows[i].Cells["QuantityRequested"];
                if (oldCell is DataGridViewNumericUpDownCell)
                {
                    DataGridViewNumericUpDownCell numericCell = new DataGridViewNumericUpDownCell();
                    int caseSize = (from itm in items where itm.ItemId == orderItems[i].itemID select itm.CaseSize).FirstOrDefault();

                    numericCell.Minimum = caseSize > 0 ? caseSize : 1;
                    numericCell.Increment = caseSize > 0 ? caseSize : 1;
                    numericCell.Value = orderItems[i].quantityRequested;

                    dgvOrderItems.Rows[i].Cells["QuantityRequested"] = numericCell;
                }
            }
        }

        private void RemoveColumnsFromDGV(List<string> rows, DataGridView dgv)
        {
            foreach (string name in rows)
            {
                dgv.Columns.Remove(name);
            }
        }

        private void txtInventorySearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtInventorySearch.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsBullseyeInventory.RemoveFilter();
            }
            else
            {
                bsBullseyeInventory.Filter = $"Name LIKE '*{filterText}*' OR Description LIKE '*{filterText}*' OR Category LIKE '*{filterText}*'";
            }
        }

        private void HideColumnsInDGV(List<string> cols, DataGridView dgv)
        {
            foreach (string name in cols)
            {
                if (dgv.Columns.Contains(name))
                {
                    dgv.Columns[name].Visible = false;
                }
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (lblOrderType.Text == "Emergency" && dgvOrderItems.Rows.Count >= 5)
            {
                MessageBox.Show("Emergency items may have a maximum of five different products", "Emergency Order Item Limit Reached");
                return;
            }

            if (dgvBullseyeInventory.SelectedRows.Count == 1)
            {
                // Get the selected row from Inventory DataGridView
                DataGridViewRow selectedRow = dgvBullseyeInventory.SelectedRows[0];

                // Extract data from the selected row
                int itemId = Convert.ToInt32(selectedRow.Cells["ItemId"].Value);
                string itemName = selectedRow.Cells["Name"].Value.ToString();
                string itemCategory = selectedRow.Cells["Category"].Value.ToString();
                int caseSize = Convert.ToInt32(selectedRow.Cells["CaseSize"].Value);

                // Check if the item is already in the order
                foreach (DataGridViewRow orderRow in dgvOrderItems.Rows)
                {
                    if (Convert.ToInt32(orderRow.Cells["itemID"].Value) == itemId)
                    {
                        MessageBox.Show("This item is already in the order.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Create a new order item
                dtoOrderItem newItem = new dtoOrderItem
                {
                    itemID = itemId,
                    productName = itemName,
                    quantityRequested = caseSize,
                    quantityAtWarehouse = 0
                };

                // Add the new item to the BindingList
                BindingList<dtoOrderItem> orderItems = bsOrderItems.DataSource as BindingList<dtoOrderItem>;
                orderItems.Add(newItem);

                // Refresh the DataGridView
                bsOrderItems.ResetBindings(false);

                // Set the NumericUpDown Cell for quantity input
                DataGridViewNumericUpDownCell numericCell = new DataGridViewNumericUpDownCell();
                numericCell.Value = newItem.quantityRequested;
                numericCell.Increment = caseSize;
                numericCell.Minimum = caseSize;

                // Add the numeric cell to the last added row
                int newRowIndex = dgvOrderItems.Rows.Count - 1;
                dgvOrderItems.Rows[newRowIndex].Cells["QuantityRequested"] = numericCell;

                // MessageBox.Show($"Item '{itemName}' added to the order.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an item from the inventory to add.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearSearchBar_Click(object sender, EventArgs e)
        {
            txtInventorySearch.Text = "";
        }

        private void dgvOrderItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrderItems.Columns.Count - 1)
            {
                dgvOrderItems.CurrentCell = dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvOrderItems.BeginEdit(true);
            }
        }

        private void btnExitWithoutSaving_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSaveAndExit_Click(object sender, EventArgs e)
        {

            if (dtpBackorderDate.Visible && dtpBackorderDate.Value < DateTime.Now)
            {
                MessageBox.Show("Invalid backorder date set. Backorder date cannot be earlier than the current date", "Invalid delivery date selected");
                return;
            }

            try
            {
                await SaveOrderModifications();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update the order. Please try again.", "Unable to update order");
            }

        }

        private async void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (dtpBackorderDate.Visible && dtpBackorderDate.Value < DateTime.Now)
            {
                MessageBox.Show("Invalid backorder date set. Backorder date cannot be earlier than the current date", "Invalid delivery date selected");
                return;
            }

            try
            {
                await SaveOrderModifications();

                if (lblOrderType.Text == "Standard" || lblOrderType.Text == "Emergency")
                {

                    BindingList<Txnitem> itemList = await _transactionController.GetTxnItemsFromOrder(_orderID);

                    int siteID = (this.Tag as Txn).SiteIdfrom;
                    // New list to hold new items.
                    List<Txnitem> newBackorderItems = new List<Txnitem>();

                    foreach (Txnitem item in itemList)
                    {
                        int inventoryAvailableAtWarehouse = await _inventoryController.GetInventoryForLocationByItem(2, item.ItemId, "0");

                        if (item.Quantity > inventoryAvailableAtWarehouse)
                        {

                            Txn backorder = await _transactionController.CheckForBackorder(siteID);

                            if (backorder == null)
                            {
                                backorder = await _transactionController.CreateBackorder(9998, siteID, "AUTO-GENERATED BACKORDER");
                            }

                            // Add to the backorder's transaction items.
                            BindingList<Txnitem> existingBackorderItems = await _transactionController.GetTxnItemsFromOrder(backorder.TxnId);

                            int backorderQuantity = item.Quantity - inventoryAvailableAtWarehouse;

                            // Check if the item already exists in the backorder
                            var existingBackorderItem = existingBackorderItems.FirstOrDefault(b => b.ItemId == item.ItemId);

                            if (existingBackorderItem != null)
                            {
                                // Update the quantity of the existing item
                                existingBackorderItem.Quantity += backorderQuantity;
                            }
                            else
                            {
                                // Add a new item to the backorder
                                newBackorderItems.Add(new Txnitem
                                {
                                    TxnId = backorder.TxnId,
                                    ItemId = item.ItemId,
                                    Quantity = backorderQuantity
                                });
                            }
                        }
                    }
                    // Save the updates to the backorder.
                    await _transactionController.UpdateBackorder(newBackorderItems);
                }

                await _transactionController.UpdateTransactionStatus(_orderID, _employeeID, "SUBMITTED");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update the order. Please try again.", "Unable to update order");
            }
        }

        private async Task SaveOrderModifications()
        {

            // Get the order's items
            BindingList<Txnitem> itemList = await _transactionController.GetTxnItemsFromOrder(_orderID);

            if (lblOrderType.Text == "Back Order")
            {
                // Get the order
                Txn backOrder = await _transactionController.GetOrderByID(_orderID);

                if (backOrder != null)
                {
                    backOrder.ShipDate = dtpBackorderDate.Value;
                }
            }

            // Get the items in the form
            foreach (DataGridViewRow dgvr in dgvOrderItems.Rows)
            {
                int itemId = Convert.ToInt32(dgvr.Cells[0].Value);
                int newQuantity = Convert.ToInt32(dgvr.Cells[2].Value);

                // Check if the item exists in itemList
                var existingItem = itemList.FirstOrDefault(item => item.ItemId == itemId);

                if (existingItem != null)
                {
                    if (existingItem.Quantity != newQuantity)
                    {
                        existingItem.Quantity = newQuantity;
                    }
                }
                else
                {
                    // Item not found in list
                    itemList.Add(new Txnitem
                    {
                        ItemId = itemId,
                        Quantity = newQuantity,
                        TxnId = _orderID
                    });
                }
            }

            await _transactionController.SaveOrderItemChanges(_orderID, itemList.ToList());
        }
    }
}
