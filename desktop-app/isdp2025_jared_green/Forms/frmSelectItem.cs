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
    public partial class frmSelectItem : Form
    {
        private readonly IInventoryController _inventoryController;
        private readonly IItemController _itemController;
        private List<Txnitem> _itemList;
        private List<Item> _itemsOutList;
        private readonly string _lossOrReturn;

        public frmSelectItem(IInventoryController inventoryController, IItemController itemController, string lossOrReturn)
        {
            _inventoryController = inventoryController;
            _itemController = itemController;
            _lossOrReturn = lossOrReturn;
            _itemList = new List<Txnitem>();
            _itemsOutList = new List<Item>();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _itemList.Clear();
            
            foreach (DataGridViewRow dgvr in dgvItemSelect.Rows)
            {
                if (dgvr.Cells["isSelected"].Value is bool isChecked && isChecked)
                {
                    var item = new Item
                    {
                        ItemId = Convert.ToInt32(dgvr.Cells["ItemId"].Value),
                        Name = dgvr.Cells["Name"].Value?.ToString(),
                        Sku = dgvr.Cells["Sku"].Value?.ToString(),
                        Description = dgvr.Cells["Description"].Value?.ToString(),
                        Category = dgvr.Cells["Category"].Value?.ToString(),
                        Weight = Convert.ToDecimal(dgvr.Cells["Weight"].Value),
                        CaseSize = Convert.ToInt32(dgvr.Cells["CaseSize"].Value),
                        CostPrice = Convert.ToDecimal(dgvr.Cells["CostPrice"].Value),
                        RetailPrice = Convert.ToDecimal(dgvr.Cells["RetailPrice"].Value),
                        SupplierId = Convert.ToInt32(dgvr.Cells["SupplierId"].Value),
                        Notes = dgvr.Cells["Notes"].Value?.ToString(),
                        Active = Convert.ToSByte(dgvr.Cells["Active"].Value),
                    };

                _itemsOutList.Add(item);
                }
            }

            this.Tag = _itemsOutList;
            this.Close();
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
                bsProductSearch.Filter = $"Name LIKE '*{filterText}*' OR Sku LIKE '*{filterText}*' OR category LIKE '*{filterText}*'";
            }
        }

        private async void frmSelectItem_Load(object sender, EventArgs e)
        {
            // dgvItemSelect.AutoGenerateColumns = false;
            BindingList<Item> items = await _itemController.GetAllItems();
            DataTable dt = DataTableConverter.ConvertToDataTable(items);
            bsProductSearch.DataSource = dt;
            dgvItemSelect.DataSource = bsProductSearch;

            if (this.Tag != null) {
                _itemList = this.Tag as List<Txnitem>;
            } else
            {
                _itemList = new List<Txnitem>();
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


            dgvItemSelect.Columns["Description"].Visible = false;
            dgvItemSelect.Columns["Weight"].Visible = false;
            dgvItemSelect.Columns["CaseSize"].Visible = false;
            dgvItemSelect.Columns["CostPrice"].Visible = false;
            dgvItemSelect.Columns["RetailPrice"].Visible = false;
            dgvItemSelect.Columns["SupplierId"].Visible = false;
            dgvItemSelect.Columns["Notes"].Visible = false;
            dgvItemSelect.Columns["Active"].Visible = false;
            dgvItemSelect.Columns["ImageLocation"].Visible = false;
            dgvItemSelect.Columns["CategoryNavigation"].Visible = false;
            dgvItemSelect.Columns["Inventories"].Visible = false;
            dgvItemSelect.Columns["Txnitems"].Visible = false;
            dgvItemSelect.Columns["ImagePaths"].Visible = false;
            dgvItemSelect.Columns["Supplier"].Visible = false;
        }
    }
}
