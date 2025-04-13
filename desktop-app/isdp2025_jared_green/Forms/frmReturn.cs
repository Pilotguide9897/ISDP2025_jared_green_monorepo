using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
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
    public partial class frmReturn : Form
    {
        private readonly IInventoryController _inventoryController;
        private readonly IItemController _itemController;
        private readonly ITransactionController _transactionController;
        private readonly ILocationController _locationController;
        private readonly IServiceProvider _serviceProvider;
        private readonly Employee _employee;
        private readonly List<string> _employeeRoles;
        private List<Txnitem> _returnItem = new List<Txnitem>();

        public frmReturn(IItemController itemController, IInventoryController inventoryController, ITransactionController transactionController, ILocationController locationController, IServiceProvider serviceProvider, Employee employee, List<string> roles)
        {
            _inventoryController = inventoryController;
            _itemController = itemController;
            _transactionController = transactionController;
            _locationController = locationController;
            _serviceProvider = serviceProvider;
            _employee = employee;
            _employeeRoles = roles;
            InitializeComponent();
        }

        private async void frmReturn_Load(object sender, EventArgs e)
        {
            try
            {
                await InitializeFormAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}");
            }
        }

        private async Task InitializeFormAsync()
        {
            await LoadItemCbo();
            await LoadSiteCbo();

        }

        private async Task LoadItemCbo()
        {
            List<string> items = await _inventoryController.GetInventoryNames();
            cboProductName.DataSource = items.Order().ToList();
            cboProductName.SelectedIndex = 0;
        }

        private async Task LoadSiteCbo()
        {
            BindingList<Site> sites = await _locationController.GetBullseyeLocations();
            //cboReturnSite.DataSource = sites.Order().ToList();
            cboReturnSite.DataSource = sites;
            cboReturnSite.DisplayMember = "SiteName";
            cboReturnSite.SelectedItem = _employee.Site;
            if (!_employeeRoles.Contains("Administrator"))
            {
                cboReturnSite.Enabled = false;
            }
        }

        private async void btnCompleteReturn_Click(object sender, EventArgs e)
        {
            if (!Helpers.ValidateInput.IsTextFieldEmpty(txtReasonForReturn))
            {
                _returnItem.Clear();
                object rtItm = await _itemController.GetItemByName(cboProductName.Text);
                Item itm = rtItm as Item;
                Txnitem txnitem = new Txnitem()
                {
                    TxnId = 0,
                    ItemId = itm.ItemId,
                    Quantity = 1,
                    Notes = txtReasonForReturn.Text,
                };
                if (txnitem != null) {
                    _returnItem.Add(txnitem);
                }


                Txn txn = new Txn()
                {
                    TxnId = 0,
                    EmployeeId = _employee.EmployeeId,
                    SiteIdto = (cboReturnSite.SelectedItem as Site).SiteId,
                    SiteIdfrom = (cboReturnSite.SelectedItem as Site).SiteId,
                    TxnStatus = "COMPLETE",
                    ShipDate = DateTime.Now,
                    TxnType = "Return",
                    BarCode = Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    DeliveryId = 2140000000,
                    EmergencyDelivery = 0,
                    Notes = txtReasonForReturn.Text,
                    Txnitems = _returnItem
                };

                var res = await _transactionController.ProcessReturn(txn);
                if (res != null) {
                    MessageBox.Show("Successfully processed return", "Return Processed");

                    if (chkResalePossible.Checked) {
                        try
                        {
                            await _inventoryController.ModifyItemsInCirculation((cboReturnSite.SelectedItem as Site).SiteId, _returnItem[0].ItemId, 1);
                            this.Close();
                        }
                        catch (Exception ex) {
                            MessageBox.Show("An unexpected error occurred while returning the item to inventory. Please contact your admin.", "Unexpected Inventory Error");
                        }
                    } else
                    {
                        Txn lossTxn = new Txn()
                        {
                            TxnId = 0,
                            EmployeeId = _employee.EmployeeId,
                            SiteIdto = (cboReturnSite.SelectedItem as Site).SiteId,
                            SiteIdfrom = (cboReturnSite.SelectedItem as Site).SiteId,
                            TxnStatus = "COMPLETE",
                            ShipDate = DateTime.Now,
                            TxnType = "Loss",
                            BarCode = Guid.NewGuid().ToString(),
                            CreatedDate = DateTime.Now,
                            DeliveryId = 2140000000,
                            EmergencyDelivery = 0,
                            Notes = txtReasonForReturn.Text,
                            Txnitems = _returnItem
                        };

                        try
                        {
                           Txn result = await _transactionController.RecordLoss(lossTxn);
                           this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An unexpected error occurred while removing the item to inventory. Please contact your admin.", "Unexpected Inventory Error");
                        }
                    }
                } else
                {
                    MessageBox.Show("Failed to process return", "Return Failed");
                }

            } else
            {
                MessageBox.Show("Please supply a reason for the return.", "Reason for return required");
            }
        }

        private void btnExitReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
