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
    public partial class frmSelectItem : Form
    {
        public frmSelectItem()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchItem.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsBullseyeInventory.RemoveFilter();
            }
            else
            {
                bsBullseyeInventory.Filter = $"Name LIKE '*{filterText}*' OR Description LIKE '*{filterText}*' OR Category LIKE '*{filterText}*'";
            }
       
        }
    }
}
