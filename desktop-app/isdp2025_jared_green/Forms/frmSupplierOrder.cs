using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace idsp2025_jared_green.Forms
{
    public partial class frmSupplierOrder : Form
    {

        private readonly IItemController _itemController;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly IServiceProvider _serviceProvider;
        private int _employeeID;
        private int _orderID;

        public frmSupplierOrder(IItemController itemController, ITransactionController transactionController, IInventoryController inventoryController, IServiceProvider serviceProvider)
        {
            _transactionController = transactionController;
            _itemController = itemController;
            _inventoryController = inventoryController;
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        private void btnAddToSupplierOrder_Click(object sender, EventArgs e)
        {
            if (dgvSupplierInventory.SelectedRows.Count == 1)
            {
                // Get the selected row from Inventory DataGridView
                DataGridViewRow selectedRow = dgvSupplierInventory.SelectedRows[0];

                // Extract data from the selected row
                int itemId = Convert.ToInt32(selectedRow.Cells["ItemId"].Value);
                string itemName = selectedRow.Cells["Name"].Value.ToString();
                string itemCategory = selectedRow.Cells["Category"].Value.ToString();
                int caseSize = Convert.ToInt32(selectedRow.Cells["CaseSize"].Value);

                // Check if the item is already in the order
                foreach (DataGridViewRow orderRow in dgvSupplierOrderCart.Rows)
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
                BindingList<dtoOrderItem> orderItems = bsSupplierOrderCart.DataSource as BindingList<dtoOrderItem>;
                orderItems.Add(newItem);

                // Refresh the DataGridView
                bsSupplierOrderCart.ResetBindings(false);

                // Set the NumericUpDown Cell for quantity input
                DataGridViewNumericUpDownCell numericCell = new DataGridViewNumericUpDownCell();
                numericCell.Value = newItem.quantityRequested;
                numericCell.Increment = caseSize;
                numericCell.Minimum = caseSize;

                // Add the numeric cell to the last added row
                int newRowIndex = dgvSupplierOrderCart.Rows.Count - 1;
                dgvSupplierOrderCart.Rows[newRowIndex].Cells["QuantityRequested"] = numericCell;
            }
            else
            {
                MessageBox.Show("Please select an item from the inventory to add.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCloseSupplierOrder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmSupplierOrder_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            // Load Inventory
            BindingList<Item> items = await _itemController.GetAllItems();
            DataTable dt = DataTableConverter.ConvertToDataTable(items);
            bsSupplierInventory.DataSource = dt;
            dgvSupplierInventory.DataSource = bsSupplierInventory;
            dgvSupplierInventory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            bsSupplierInventory.Filter = "Active = 1";


        }

        private void txtSearchSupplierInventory_TextChanged(object sender, EventArgs e)
        {
            // To support filtering, the data source must be a DataTable or DataView!!
            string filterText = txtSearchSupplierInventory.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsSupplierInventory.RemoveFilter();
            }
            else
            {
                bsSupplierInventory.Filter = $"Name LIKE '*{filterText}*' OR Description LIKE '*{filterText}*' OR Category LIKE '*{filterText}*' AND Active = 1";
            }
        }

        private void dgvSupplierInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected item...
            if (dgvSupplierInventory.Rows.Count > 0 && dgvSupplierInventory.SelectedRows.Count == 1)
            {
                frmItemInfo fio = _serviceProvider.GetRequiredService<frmItemInfo>();
                Item? selectedItem = dgvSupplierInventory.SelectedRows[0].DataBoundItem as Item;
                if (selectedItem != null)
                {
                    fio.Tag = selectedItem;
                    fio.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Unable to access item data.", "Data Error");
                }
            }
        }

        private void dgvSupplierOrderCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSupplierOrderCart.Columns[e.ColumnIndex].Name == "quantityRequested")
            {
                var cellValue = dgvSupplierOrderCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int quantity) && quantity == 0)
                {

                    var confirm = MessageBox.Show("Set to 0. Remove item?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        dgvSupplierOrderCart.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
