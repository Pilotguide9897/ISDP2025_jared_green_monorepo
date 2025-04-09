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
    public partial class frmSelectItem : Form
    {
        private readonly IInventoryController _inventoryController;
        private List<Item> _itemList;

        public frmSelectItem(IInventoryController inventoryController)
        {
            _inventoryController = inventoryController;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Get which checkboxes are selected. Add them to the list from the tag!
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchItem.Text;
            if (string.IsNullOrEmpty(filterText))
            {
                bsProductSearch.RemoveFilter();
            }
            else
            {
                bsProductSearch.Filter = $"Name LIKE '*{filterText}*'";
            }
        }

        private void frmSelectItem_Load(object sender, EventArgs e)
        {
            bsProductSearch.DataSource = _inventoryController.GetInventoryNames();
            dgvItemSelect.DataSource = bsProductSearch;

            if (this.Tag != null) {
                _itemList = this.Tag as List<Item>;
            }
            if (_itemList != null && _itemList.Count > 0)
            {
                // Check the specified checkboxes.
            }
        }
    }
}
