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
    public partial class frmSupplierOrder : Form
    {
        public frmSupplierOrder()
        {
            InitializeComponent();
        }

        private void btnAddToSupplierOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseSupplierOrder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierOrder_Load(object sender, EventArgs e)
        {

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
            }
        }
    }
}
