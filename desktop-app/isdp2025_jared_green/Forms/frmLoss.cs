using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
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
        private readonly ILocationController _locationController;
        private readonly Employee _employee;
        private readonly List<string> _employeeRoles;

        public frmLoss(IItemController itemController, IInventoryController inventoryController, ILocationController locationController, Employee employee, List<string> roles)
        {
            _inventoryController = inventoryController;
            _itemController = itemController;
            _locationController = locationController;
            _employee = employee;
            _employeeRoles = roles;
            InitializeComponent();
        }

        private void frmLoss_Load(object sender, EventArgs e)
        {
            LoadItemCbo();
            LoadSiteCbo();
            cboLossCategory.SelectedIndex = 0;
        }

        private async void LoadItemCbo()
        {
            List<string> items = await _inventoryController.GetInventoryNames();
            cboProductName.DataSource = items;
            cboProductName.SelectedIndex = 0;
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
            // 1. Validate the inputs
            // The explanatory note cannot be blank...

            // 2. Create the new Txn Object

            // 3. 

            try
            {
                if (Helpers.ValidateInput.IsTextFieldEmpty(txtLossDescription))
                {
                    MessageBox.Show("A description explaining the reason behind the loss must be provided.", "No Loss Description");
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
                    DeliveryId = 0,
                    EmergencyDelivery = 0,
                    Notes = "",
                    Txnitems = new List<Txnitem>()
                };

            }
            catch (Exception ex)
            {

            }


        }

        private void btnExitReportLoss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLossItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveLossItem_Click(object sender, EventArgs e)
        {

        }
    }
}
