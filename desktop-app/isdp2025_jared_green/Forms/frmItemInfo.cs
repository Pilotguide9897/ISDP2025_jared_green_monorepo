using idsp2025_jared_green.Entities;
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
    public partial class frmItemInfo : Form
    {
        private Item _item;
        public frmItemInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmItemInfo_Load(object sender, EventArgs e)
        {
            // Set item details
            _item = this.Tag as Item;

            if (_item != null) {
                lblProductName.Text = _item.Name;
                lblSku.Text = _item.Sku;
                lblSupplier.Text = _item.Supplier.Name;
                lblCategory.Text = _item.Category;
                txtDescription.Text = _item.Description;
                lblWeight.Text = _item.Weight.ToString();
                lblCaseSize.Text = _item.CaseSize.ToString();
                lblPrice.Text = _item.RetailPrice.ToString("C2");

            } else
            {
                MessageBox.Show("There was a problem accessing the item's information.", "Please try again");
                this.Close();
            }
            
        }
    }
}
