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
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green
{
    public partial class frmUpdateItem : Form
    {
        private Item _item;
        private BindingList<string>? _imagePaths;
        private readonly IItemController _itemController;
        private readonly ISupplierController _supplierController;
        public frmUpdateItem(Item item, IItemController itemController, ISupplierController supplierController)
        {
            _item = item;
            _itemController = itemController;
            _supplierController = supplierController;
            InitializeComponent();
            PopulateFields(_item);
        }

        private async Task<BindingList<string>> GetItemImages(Item item)
        {
            return await _itemController.GetImagePaths(item.ItemId);
        }

        private void PopulateFields(Item item)
        {
            lblItemSKU.Text = _item.Sku.ToString();
            chkItemActive.Checked = _item.Active == 1 ? true : false;
            txtUpdateItemDescription.Text = _item.Description;
            txtUpdateItemNotes.Text = _item.Notes;
        }

        private async void btnUpdateItem_Click(object sender, EventArgs e)
        {
            _item.Active = (sbyte)(chkItemActive.Checked ? 1 : 0);
            _item.Description = txtUpdateItemDescription.Text;
            _item.Notes = txtUpdateItemNotes.Text;
            //_item.ImageLocation = cboImageSelect.DisplayMember;

            if (await _itemController.UpdateItem(_item))
            {
                this.Close();
            }
        }

        private void btnCancelItemUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
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

                UpdatePictureBoxDisplay(_item.ImageLocation);

                await InitializeCboImages();

                await _itemController.UpdateItem(_item);
            }
            catch (Exception ex) {
                MessageBox.Show("There was an error adding your desired image.");
            }
        }

        private void UpdatePictureBoxDisplay(string path)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imagesDirectory = Path.Combine(projectDirectory, "ImagesFolder");
            picItemImage.ImageLocation = Path.Combine(imagesDirectory, path);
            picItemImage.Refresh();
        }

        private void cboImageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboImageSelect.SelectedIndex != -1 && cboImageSelect.SelectedItem != null && cboImageSelect.Focused)
            {
                string selectedImagePath = cboImageSelect.SelectedItem.ToString();
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string imagesDirectory = Path.Combine(projectDirectory, "ImagesFolder");
                picItemImage.ImageLocation = Path.Combine(imagesDirectory, selectedImagePath);
                picItemImage.Refresh();
            }
        }

        private async void frmUpdateItem_Load(object sender, EventArgs e)
        {
            await InitializeCboImages();
            LoadSupplierCbo();
        }

        private async void LoadSupplierCbo()
        {
            BindingList<Supplier> suppliers = await _supplierController.GetSuppliers();
            cboSupplier.DataSource = suppliers;
            cboSupplier.DisplayMember = "Name";
            Supplier sup = (from s in suppliers where s.SupplierId == _item.SupplierId select s).FirstOrDefault();
            if (sup != null) {
                cboSupplier.SelectedText = sup.Name;
            } else
            {
                cboSupplier.SelectedIndex = 0;
            }
        }

        private async Task InitializeCboImages()
        {
            cboImageSelect.Items.Clear();
            _imagePaths = await GetItemImages(_item);
            if (_imagePaths != null && _imagePaths.Count != 0)
            {
                cboImageSelect.Visible = true;
                foreach (string imagePath in _imagePaths)
                {
                    cboImageSelect.Items.Add(imagePath);
                }
                int imageIndex = cboImageSelect.Items.IndexOf(_item.ImageLocation);
                if (imageIndex != -1)
                {
                    cboImageSelect.SelectedIndex = imageIndex;
                    UpdatePictureBoxDisplay(_item.ImageLocation);
                }
            }
            else
            {
                cboImageSelect.Visible = false;
            }

        }

        private void frmUpdateItem_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Update an item's information in our records. Modify the description and notes by typing in the respective text fields. Set whether the item is available for sale by checking the 'active' checkbox. If an item has one or more images saved to our system, the image currently set to the product will be displayed. If there are more photographs on file, a dropdown box will appear to allow you to select the image you would like. To add a new image, click the 'add image' button to open a file viewer where you can select a picture from your system. Once all the desired changes are made, click the update button to submit. Otherwise, click the cancel button to undo any changes.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
