using idsp2025_jared_green.Entities;
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
    public partial class frmAddSupplierProduct : Form
    {
        public readonly ISupplierController _supplierController;
        public readonly IInventoryController _inventoryController;


        public frmAddSupplierProduct(ISupplierController supplierController, IInventoryController inventoryController)
        {
            _supplierController = supplierController;
            _inventoryController = inventoryController;
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
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {

        }
    }
}
