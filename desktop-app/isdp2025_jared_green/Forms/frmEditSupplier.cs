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

namespace idsp2025_jared_green.Forms
{
    public partial class frmEditSupplier : Form
    {
        private readonly ISupplierController _supplierController;
        public frmEditSupplier(ISupplierController supplierController)
        {
            _supplierController = supplierController;
            InitializeComponent();
        }

        private void frmEditSupplier_Load(object sender, EventArgs e)
        {
            Supplier supplierToEdit = this.Tag as Supplier;
            if (supplierToEdit == null) {
                MessageBox.Show("There was a problem passing the supplier information to the update form, please try again", "Supplier passing failed");
                this.Close();
            }
            // Set the form data
            chkSupplierActive.Checked = supplierToEdit.Active == 1 ? true : false;
            txtEditSupplierName.Text = supplierToEdit.Name;
            txtEditSupplierAddress.Text = supplierToEdit.Address1;
            txtEditSupplierCity.Text = supplierToEdit.City;
            cboEditSupplierProvince.SelectedItem = supplierToEdit.Province;
            cboEditSupplierCountry.SelectedItem = supplierToEdit.Country;
            txtEditSupplierPostalCode.Text = supplierToEdit.Postalcode;
            txtEditSupplierPhone.Text = supplierToEdit.Phone;
            txtEditSupplierContact.Text = supplierToEdit.Contact;
            txtEditSupplierNotes.Text = supplierToEdit.Notes;

            txtEditSupplierName.Focus();
        }

        private async void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierName))
            {
                MessageBox.Show("The 'Name' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierAddress))
            {
                MessageBox.Show("The 'Address' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierCity))
            {
                MessageBox.Show("The 'City' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierPostalCode))
            {
                MessageBox.Show("The 'Postal Code' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierPhone))
            {
                MessageBox.Show("The 'Phone' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtEditSupplierContact))
            {
                MessageBox.Show("The 'Contact' field cannot be left empty.", "Input field cannot be empty");
                return;
            }

            // Update the object data
            Supplier supplierToUpdate = this.Tag as Supplier;

            supplierToUpdate.Name = txtEditSupplierName.Text;
            supplierToUpdate.Address1 = txtEditSupplierAddress.Text;
            supplierToUpdate.City = txtEditSupplierCity.Text;
            supplierToUpdate.Postalcode = txtEditSupplierPostalCode.Text;
            supplierToUpdate.Phone = txtEditSupplierPhone.Text;
            supplierToUpdate.Contact = txtEditSupplierContact.Text;
            supplierToUpdate.Notes = txtEditSupplierNotes.Text;
            supplierToUpdate.Province = cboEditSupplierProvince.Text;
            supplierToUpdate.Country = cboEditSupplierCountry.Text;
            supplierToUpdate.Active = (sbyte) (chkSupplierActive.Checked ? 1 : 0);

            Supplier result = await _supplierController.EditSupplier(supplierToUpdate);
            if (result != null)
            {
                MessageBox.Show($"Supplier {result.Name} updated.", "Supplier Updated");
                this.Close();
            }
            else
            {
                MessageBox.Show($"Unable to update supplier {txtEditSupplierName}.", "Supplier update failed");
            }
        }

        private void btnCancelSupplierUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
