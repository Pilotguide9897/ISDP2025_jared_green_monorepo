﻿using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green.Forms
{
    public partial class frmLoss : Form
    {
        private readonly IInventoryController _inventoryController;
        private readonly IItemController _itemController;
        private readonly ITransactionController _transactionController;
        private readonly ILocationController _locationController;
        private readonly IServiceProvider _serviceProvider;
        private readonly Employee _employee;
        private readonly List<string> _employeeRoles;
        private List<Txnitem> _lossItems;
        private List<dtoLossItem> _li;

        public frmLoss(IItemController itemController, IInventoryController inventoryController, ITransactionController transactionController, ILocationController locationController, IServiceProvider serviceProvider, Employee employee, List<string> roles)
        {
            _inventoryController = inventoryController;
            _itemController = itemController;
            _transactionController = transactionController;
            _locationController = locationController;
            _serviceProvider = serviceProvider;
            _employee = employee;
            _employeeRoles = roles;
            _lossItems = new List<Txnitem>();
            _li = new List<dtoLossItem>();
            InitializeComponent();
        }

        private void frmLoss_Load(object sender, EventArgs e)
        {
            LoadSiteCbo();
            dgvLossItems.AutoGenerateColumns = false;
            cboLossCategory.SelectedIndex = 0;
        }

        private async void LoadSiteCbo()
        {
            BindingList<Site> sites = await _locationController.GetBullseyeLocations();
            cboLossSite.DataSource = sites;
            cboLossSite.DisplayMember = "SiteName";
            cboLossSite.SelectedItem = _employee.Site;
            if (!_employeeRoles.Contains("Administrator"))
            {
                cboLossSite.Enabled = false;
            }
        }


        private async void btnConfirmLoss_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helpers.ValidateInput.IsTextFieldEmpty(txtLossDescription))
                {
                    MessageBox.Show("A description explaining the reason behind the loss must be provided.", "No Loss Description");
                    return;
                }

                if (_li.Count < 1)
                {
                    MessageBox.Show("One or more loss items must be specified.", "No Loss Items");
                    return;
                }

                Txn txn = new Txn()
                {
                    TxnId = 0,
                    EmployeeId = _employee.EmployeeId,
                    SiteIdto = (cboLossSite.SelectedItem as Site).SiteId,
                    SiteIdfrom = (cboLossSite.SelectedItem as Site).SiteId,
                    TxnStatus = "COMPLETE",
                    ShipDate = DateTime.Now,
                    TxnType = "Loss",
                    BarCode = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    DeliveryId = 2140000000,
                    EmergencyDelivery = 0,
                    Notes = txtLossDescription.Text,
                    Txnitems = _lossItems
                };

                // Create Loss
                var result = await _transactionController.RecordLoss(txn);
                // Modify Inventory
                if (result != null) {
                    foreach (var item in _li)
                    {
                        await _inventoryController.ModifyItemsInCirculation((cboLossSite.SelectedItem as Site).SiteId, item.itemID, -(item.quantity));
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred processing the loss.", "Please try again");
            }
        }

        private void btnExitReportLoss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLossItem_Click(object sender, EventArgs e)
        {
            var formFactory = _serviceProvider.GetRequiredService<Func<string, frmSelectItem>>();
            frmSelectItem fsi = formFactory("Loss");
            fsi.Tag = _lossItems;
            fsi.ShowDialog();
            List<Item> tis = fsi.Tag as List<Item>;
            foreach (Txnitem txi in _lossItems)
            {
                if (tis.Where(t => t.ItemId == txi.ItemId).FirstOrDefault() == null)
                {
                    _lossItems.Remove(txi);
                }
            }

            foreach (var item in tis)
            {
                _lossItems.Add(
                    new Txnitem {
                        TxnId = 0,
                        ItemId = item.ItemId,
                        Quantity = 1,
                        Notes = ""
                    }
                );

                _li.Add(
                    new dtoLossItem {
                        itemID = item.ItemId,
                        productName = item.Name,
                        quantity = 1
                    });
            }

            dgvLossItems.Columns["Quantity"].DataPropertyName = "quantity";
            dgvLossItems.Columns["Product"].DataPropertyName = "productName";
            bsLossItems.DataSource = _li;
            dgvLossItems.DataSource = bsLossItems;
        }

        private void btnRemoveLossItem_Click(object sender, EventArgs e)
        {
            if (dgvLossItems.SelectedRows.Count == 1) {
                var confirm = MessageBox.Show("Remove item from loss accounting?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dgvLossItems.Rows.RemoveAt(dgvLossItems.SelectedRows[0].Index);
                }
            }
        }
    }
}
