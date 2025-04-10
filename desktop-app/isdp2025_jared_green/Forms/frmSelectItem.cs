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
        private readonly string _lossOrReturn;

        public frmSelectItem(IInventoryController inventoryController, string lossOrReturn)
        {
            _inventoryController = inventoryController;
            _lossOrReturn = lossOrReturn;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _itemList.Clear();

            // Get which checkboxes are selected. Add them to the list from the tag!
            var allItems = bsProductSearch.List.Cast<Item>();
            foreach (var item in allItems)
            {
                if (item.IsSelected)
                {
                    _itemList.Add(item);
                }
            }

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
                bsProductSearch.Filter = $"productName LIKE '*{filterText}*' OR sku LIKE '*{filterText}*' OR supplier LIKE '*{filterText}*' OR category LIKE '*{filterText}*'";
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
                HashSet<int> idsOfItems = new HashSet<int>(_itemList.Select(i => i.ItemId));

                foreach (DataGridViewRow dataGridViewRow in dgvItemSelect.Rows) {
                    if (dataGridViewRow.DataBoundItem is Item rowItem && idsOfItems.Contains(rowItem.ItemId))
                    {
                        dataGridViewRow.Cells["Select"].Value = true;
                    }
                }

            }
        }
    }
}
