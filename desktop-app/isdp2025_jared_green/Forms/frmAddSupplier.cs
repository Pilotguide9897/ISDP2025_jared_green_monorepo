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

namespace idsp2025_jared_green.Forms
{
    public partial class frmAddSupplier : Form
    {
        private readonly ISupplierController _supplierController;
        public frmAddSupplier(ISupplierController supplierController)
        {
            _supplierController = supplierController;
            InitializeComponent();
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            cboAddSupplierProvince.SelectedIndex = 3;
            cboAddSupplierCountry.SelectedIndex = 0;
        }

        private async void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierName))
            {
                MessageBox.Show("The 'Name' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierAddress))
            {
                MessageBox.Show("The 'Address' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierCity))
            {
                MessageBox.Show("The 'City' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierPostalCode))
            {
                MessageBox.Show("The 'Postal Code' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierPhone))
            {
                MessageBox.Show("The 'Phone' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierContact))
            {
                MessageBox.Show("The 'Contact' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtAddSupplierNotes))
            {
                MessageBox.Show("The 'Notes' field cannot be left empty.", "Input field cannot be empty");
                return;
            }

            // Create the new supplier with the data
            Supplier ns = new Supplier()
            {
                SupplierId = 0,
                Name = txtAddSupplierName.Text,
                Address1 = txtAddSupplierAddress.Text,
                Address2 = "",
                City = txtAddSupplierCity.Text,
                Country = cboAddSupplierCountry.Text,
                Province = cboAddSupplierProvince.Text,
                Postalcode = txtAddSupplierPostalCode.Text,
                Phone = txtAddSupplierPhone.Text,
                Contact = txtAddSupplierContact.Text,
                Notes = txtAddSupplierNotes.Text,
                Active = 1
            };

            Supplier result = await _supplierController.AddSupplier(ns);
            if (result != null)
            {
                MessageBox.Show($"Supplier {result.Name} created.", "Supplier Created");
                this.Close();
            }
            else
            {
                MessageBox.Show($"Unable to create supplier {txtAddSupplierName.Text}.", "Supplier addition failed");
            }
        }


        private async void btnCancelAddSupplier_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
