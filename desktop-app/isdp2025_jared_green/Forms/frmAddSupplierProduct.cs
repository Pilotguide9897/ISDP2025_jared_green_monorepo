using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
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
using System.Xml.Linq;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Forms
{
    public partial class frmAddSupplierProduct : Form
    {
        public readonly ISupplierController _supplierController;
        public readonly IInventoryController _inventoryController;
        public readonly IItemController _itemController;
        private Item _item;


        public frmAddSupplierProduct(ISupplierController supplierController, IInventoryController inventoryController, IItemController itemController)
        {
            _supplierController = supplierController;
            _inventoryController = inventoryController;
            _itemController = itemController;
            InitializeComponent();
        }

        private void btnExitProductAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmAddSupplierProduct_Load(object sender, EventArgs e)
        {
            BindingList<Supplier> suppliers = await _supplierController.GetSuppliers();
            cboSuppliers.DataSource = suppliers;
            cboSuppliers.DisplayMember = "Name";
            _item = await CreatePlaceholderItem();
        }

        public async Task<Item> CreatePlaceholderItem()
        {
            return new Item
            {
                Name = "TEMP_ITEM",
                Sku = $"TEMP-{Guid.NewGuid().ToString("N").Substring(0, 8)}",
                Description = "Placeholder item for later update",
                Category = "TEMP",
                Weight = 0m,
                CaseSize = 1,
                CostPrice = 0.00m,
                RetailPrice = 0.00m,
                SupplierId = 10000,
                Notes = "Auto-generated placeholder",
                Active = 1,
                IsSelected = false,
                ImageLocation = null
            };

            Item newProduct = (await _itemController.AddProduct(_item)) as Item;

            return newProduct;
        }

        private async void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                string imageTitle = ImageManipulation.CopyImageToFolder(ofdAddImage, _item.ItemId);
                // Set the new image to be the selected one...
                _item.ImageLocation = imageTitle;
                Image newImage = await _itemController.AddImage(_item.ImageLocation);

                await _itemController.AddImagePath(_item.ItemId, newImage.ImageID);
                _item.ImageLocation = newImage.ImagePath;

                await _itemController.UpdateItem(_item);

                MessageBox.Show("New Image Added", "Image Uploaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error adding your desired image.");
            }
        }

        private async void btnAddSupplierProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Check all required fields are filled
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show("Item name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtCategory.Text))
                {
                    MessageBox.Show("Category is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (nudWeight.Value > 0)
                {
                    MessageBox.Show("Please enter a valid weight.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (nudCaseSize.Value > 1)
                {
                    MessageBox.Show("Please enter a valid case size.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (nudCostPrice.Value > 0)
                {
                    MessageBox.Show("Please enter a valid cost price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (nudRetailPrice.Value > nudCostPrice.Value)
                {
                    MessageBox.Show("Please enter a valid retail price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (cboSuppliers.SelectedItem == null)
                {
                    MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update item properties
                _item.Name = txtProductName.Text;
                _item.Description = txtDescription.Text;
                _item.Category = txtCategory.Text;
                _item.Weight = nudWeight.Value;
                _item.CaseSize = Convert.ToInt32(nudCaseSize.Value);
                _item.CostPrice = nudCostPrice.Value;
                _item.RetailPrice = nudRetailPrice.Value;
                _item.SupplierId = ((Supplier)cboSuppliers.SelectedItem).SupplierId;
                _item.Notes = txtNotes.Text;

                bool res = await _itemController.UpdateItem(_item);
                if (res) { 
                    this.Close(); 
                } else
                {
                    MessageBox.Show("Error: failed saving new item.", "Unable to add item");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: Unable to add the new item.", "Unable to add item");
            }
        }
    }
}
