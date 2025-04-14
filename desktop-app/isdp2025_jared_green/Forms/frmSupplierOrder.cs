using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
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
        private readonly ISupplierController _supplierController;
        private readonly Employee _employee;

        public frmSupplierOrder(IItemController itemController, ITransactionController transactionController, ISupplierController supplierController, IInventoryController inventoryController, IServiceProvider serviceProvider, Employee employee)
        {
            _transactionController = transactionController;
            _supplierController = supplierController;
            _itemController = itemController;
            _inventoryController = inventoryController;
            _serviceProvider = serviceProvider;
            _employee = employee;
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
                string supplier = (selectedRow.Cells["Supplier"].Value as Supplier).Name;

                // Check if the item is already in the order
                foreach (DataGridViewRow orderRow in dgvSupplierOrderCart.Rows)
                {
                    if (orderRow.Cells["productName"].Value == itemName)
                    {
                        MessageBox.Show("This item is already in the order.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Create a new order item
                dtoSupplierOrderItem newItem = new dtoSupplierOrderItem
                {
                    itemID = itemId,
                    supplierName = supplier,
                    productName = itemName,
                    quantityRequested = caseSize,
                };

                // Add the new item to the BindingList
                List<dtoSupplierOrderItem> orderItems = bsSupplierOrderCart.DataSource as List<dtoSupplierOrderItem>;
                orderItems.Add(newItem);

                // Refresh the DataGridView
                bsSupplierOrderCart.ResetBindings(false);

                //// Set the NumericUpDown Cell for quantity input
                //DataGridViewNumericUpDownCell numericCell = new DataGridViewNumericUpDownCell();
                //numericCell.Value = newItem.quantityRequested;
                //numericCell.Increment = caseSize;
                //numericCell.Minimum = caseSize;

                //// Add the numeric cell to the last added row
                //int newRowIndex = dgvSupplierOrderCart.Rows.Count - 1;
                //dgvSupplierOrderCart.Rows[newRowIndex].Cells["QuantityRequested"] = numericCell;
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
            dgvSupplierOrderCart.AutoGenerateColumns = false;
            await LoadData();
            await LoadResupply();
            await LoadSuppliers();
        }

        private async Task LoadSuppliers()
        {
            try
            {
                BindingList<Supplier> Suppliers = await _supplierController.GetSuppliers();
                cboSuppliers.DataSource = Suppliers;
                cboSuppliers.DisplayMember = "Name";
                cboSuppliers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem occurred gathering the supplier information.", "No supplier info");
            }



        }

        private async Task LoadResupply()
        {
            var resupply = await _inventoryController.GetWarehouseResupply();
            if (resupply is List<dtoSupplierOrderItem> && ((List<dtoSupplierOrderItem>)resupply).Count > 0)
            {
                dgvSupplierOrderCart.Columns["productName"].DataPropertyName = "productName";
                dgvSupplierOrderCart.Columns["supplier"].DataPropertyName = "supplierName";
                dgvSupplierOrderCart.Columns["quantityRequested"].DataPropertyName = "quantityRequested";

                bsSupplierOrderCart.DataSource = resupply;
                dgvSupplierOrderCart.DataSource = bsSupplierOrderCart;
            } else if (resupply is List<dtoSupplierOrderItem> && ((List<dtoSupplierOrderItem>)resupply).Count < 0)
            {
                MessageBox.Show("No items in need of resupply by default: All stock above reorder threshold.", "No items automatically added");
            }
            else
            {
                MessageBox.Show("There was a problem with the data returned when trying to detect the required supply.", "No items automatically added");
            }
        }

        private async Task LoadData()
        {
            // Load Inventory
            BindingList<Item> items = await _itemController.GetAllItems();
            DataTable dt = DataTableConverter.ConvertToDataTable(items);
            bsSupplierInventory.DataSource = dt;

            dgvSupplierInventory.DataSource = bsSupplierInventory;
            dgvSupplierInventory.Columns["Description"].Visible = false;
            dgvSupplierInventory.Columns["Weight"].Visible = false;
            dgvSupplierInventory.Columns["CaseSize"].Visible = false;
            dgvSupplierInventory.Columns["CostPrice"].Visible = false;
            dgvSupplierInventory.Columns["RetailPrice"].Visible = false;
            dgvSupplierInventory.Columns["SupplierId"].Visible = false;
            dgvSupplierInventory.Columns["Notes"].Visible = false;
            dgvSupplierInventory.Columns["Active"].Visible = false;
            dgvSupplierInventory.Columns["ImageLocation"].Visible = false;
            dgvSupplierInventory.Columns["CategoryNavigation"].Visible = false;
            dgvSupplierInventory.Columns["Inventories"].Visible = false;
            dgvSupplierInventory.Columns["Txnitems"].Visible = false;
            dgvSupplierInventory.Columns["ImagePaths"].Visible = false;
            dgvSupplierInventory.Columns["Supplier"].Visible = false;
            dgvSupplierInventory.Columns["isSelected"].Visible = false;
            dgvSupplierInventory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            bsSupplierInventory.Filter = "Active = 1";
        }

        private void txtSearchSupplierInventory_TextChanged(object sender, EventArgs e)
        {
            // To support filtering, the data source must be a DataTable or DataView!!
            var selectedSupplier = cboSuppliers.SelectedItem as Supplier;
            string filterText = txtSearchSupplierInventory.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsSupplierInventory.RemoveFilter();
                bsSupplierInventory.Filter = $"SupplierId = {(cboSuppliers.SelectedItem as Supplier).SupplierId}";
            }
            else
            {
                bsSupplierInventory.Filter = $"(Name LIKE '*{filterText}*' OR Description LIKE '*{filterText}*' OR Category LIKE '*{filterText}*') AND Active = 1 AND SupplierId = {selectedSupplier.SupplierId}";
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

        private async void btnCreateSupplierOrder_Click(object sender, EventArgs e)
        {
            // Get all the rows of the cart
            try
            {
                List<Txnitem> itemList = new List<Txnitem>();
                // Add Items to it
                foreach (DataGridViewRow dataGridViewRow in dgvSupplierOrderCart.Rows)
                {
                    dtoSupplierOrderItem oi = dataGridViewRow.DataBoundItem as dtoSupplierOrderItem;
                    if (oi != null)
                    {
                        Txnitem ti = new Txnitem()
                        {
                            TxnId = 0,
                            ItemId = oi.itemID,
                            Quantity = oi.quantityRequested,
                            Notes = ""
                        };

                        itemList.Add(ti);
                    }
                }

                // Create a string with all the supplier ids.
                string supplierString = "";

                // Create transaction
                Txn txn = new Txn()
                {
                    TxnId = 0,
                    EmployeeId = _employee.EmployeeId,
                    SiteIdto = 10002,
                    SiteIdfrom = 2,
                    TxnStatus = "SUBMITTED",
                    ShipDate = DateTime.Now,
                    TxnType = "Supplier Order",
                    BarCode = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    DeliveryId = 2140000000,
                    EmergencyDelivery = 0,
                    Notes = supplierString,
                    Txnitems = itemList
                };

                Txn res = await _transactionController.CreateSupplierOrder(txn);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred trying to create the supplier order.", "Error creating Supplier Order");
            }
        }

        private void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSupplier = cboSuppliers.SelectedItem as Supplier;
            string filterText = txtSearchSupplierInventory.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsSupplierInventory.RemoveFilter();
                if (selectedSupplier != null)
                {
                    bsSupplierInventory.Filter = $"SupplierId = {selectedSupplier.SupplierId}";
                }

            }
            else
            {
                bsSupplierInventory.Filter = $"(Name LIKE '*{filterText}*' OR Description LIKE '*{filterText}*' OR Category LIKE '*{filterText}*') AND Active = 1 AND SupplierId = {selectedSupplier.SupplierId}";
            }
        }
    }
}
