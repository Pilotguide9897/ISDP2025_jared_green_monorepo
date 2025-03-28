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
    public partial class frmModifyTxnRecord : Form
    {
        private readonly ITransactionController _transactionController;
        private readonly ILocationController _locationController;
        private readonly int _employeeID;
        private BindingList<Site> _sites;
        private List<Txnaudit> _txnAuditList;

        public frmModifyTxnRecord(ITransactionController transactionController, ILocationController locationController, int employeeID)
        {
            _transactionController = transactionController;
            _locationController = locationController;
            _employeeID = employeeID;
            InitializeComponent();
        }

        private async void frmModifyTxnRecord_Load(object sender, EventArgs e)
        {
            _sites = await _locationController.GetBullseyeLocations();
            List<string> txnStatuses = new List<string>
            {
                "ASSEMBLED",
                "ASSEMBLING",
                "CANCELLED",
                "COMPLETE",
                "DELIVERED",
                "IN TRANSIT",
                "NEW",
                "PREPARED",
                "PREPARING",
                "RECEIVED",
                "REJECTED",
                "SUBMITTED"
            };

            cboUpdateTxnStatus.DataSource = txnStatuses;


            // Set the data
            if (this.Tag != null)
            {
                Txn txn = this.Tag as Txn;

                if (txn != null)
                {
                    lblEditTxnID.Text = txn.TxnId.ToString();
                    dtpUpdateTxnDate.Value = txn.CreatedDate;

                    cboUpdateTxnStatus.SelectedItem = txn.TxnStatus.ToString();

                    foreach (Site site in _sites)
                    {
                        cboUpdateSiteFrom.Items.Add(site);
                        cboUpdateSiteTo.Items.Add(site);
                    }

                    cboUpdateSiteFrom.SelectedItem = (from site in _sites where site.SiteId == txn.SiteIdfrom select site).FirstOrDefault();
                    cboUpdateSiteTo.SelectedItem = (from site in _sites where site.SiteId == txn.SiteIdto select site).FirstOrDefault();
                    txtUpdateBarcode.Text = txn.BarCode.ToString();
                    txtUpdateDelivery.Text = txn.DeliveryId.ToString();
                    _txnAuditList = await _transactionController.GetTransactionAudit(txn.TxnId);
                    chkSetEmergency.Checked = txn.EmergencyDelivery == 1 ? true : false;

                    foreach(var txnAudit in _txnAuditList)
                    {
                        lstTxnRecord.Items.Add(txnAudit);
                    }
                }
                else
                {
                    MessageBox.Show("The data passed to the form for editing was not a transaction.", "Unable to update transaction");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No transaction data was passed to the form for updating, please try again.", "Unable to update transaction");
                this.Close();
            }
        }

        private async void btnUpdateTransaction_Click(object sender, EventArgs e)
        {

            if (dtpUpdateTxnDate.Value == null)
            {
                MessageBox.Show("A transaction date must be provided, field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (cboUpdateTxnStatus.SelectedIndex < 0)
            {
                MessageBox.Show("A transaction status must be selected.", "Input field cannot be empty");
                return;
            }
            if (dtpUpdateTxnDate.Value == null)
            {
                MessageBox.Show("A transaction date must be provided, field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (cboUpdateSiteFrom.SelectedIndex < 0)
            {
                MessageBox.Show("A 'From' site must be selected.", "Input field cannot be empty");
                return;
            }
            if (cboUpdateSiteTo.SelectedIndex < 0)
            {
                MessageBox.Show("A 'To' site must be selected.", "Input field cannot be empty");
                return;
            }
            if (cboUpdateSiteFrom.SelectedIndex == cboUpdateSiteTo.SelectedIndex)
            {
                MessageBox.Show("The 'To' and 'From' sites cannot be the same.", "Invalid information entry");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtUpdateBarcode))
            {
                MessageBox.Show("The 'Barcode' field cannot be left empty.", "Input field cannot be empty");
                return;
            }
            if (ValidateInput.IsTextFieldEmpty(txtUpdateDelivery))
            {
                MessageBox.Show("The 'Delivery' field cannot be left empty.", "Input field cannot be empty");
                return;
            }

            int def = -1;
            if (Int32.TryParse(txtUpdateDelivery.Text, out def));

            Txn tBefore = this.Tag as Txn;

            Txn updatedTransaction = new Txn()
            {
                TxnId = tBefore.TxnId,
                EmployeeId = _employeeID,
                SiteIdto = (from sites in _sites where sites.SiteName == cboUpdateSiteTo.Text select sites.SiteId).FirstOrDefault(),
                SiteIdfrom = (from sites in _sites where sites.SiteName == cboUpdateSiteFrom.Text select sites.SiteId).FirstOrDefault(),
                TxnStatus = cboUpdateTxnStatus.Text,
                ShipDate = dtpUpdateTxnDate.Value,
                TxnType = tBefore.TxnType,
                BarCode = txtUpdateBarcode.Text,
                CreatedDate = tBefore.CreatedDate,
                DeliveryId = def == -1 ? tBefore.DeliveryId : def,
                EmergencyDelivery = (sbyte)(chkSetEmergency.Checked ? 1 : 0),
                Notes = tBefore.Notes
            };

            bool result = await _transactionController.UpdateTransactionDetails(updatedTransaction);

            if (result)
            {
                this.Close();
            }
        }

        private void btnCancelTransactionEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
