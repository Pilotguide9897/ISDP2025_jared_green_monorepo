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
    public partial class frmEditLocation : Form
    {
        private readonly ILocationController _locationController;
        public frmEditLocation(ILocationController location)
        {
            _locationController = location;
            InitializeComponent();
        }

        private void frmEditLocation_Load(object sender, EventArgs e)
        {
            //cboUpdateCountry.Items.Clear();
            //cboUpdateDeliveryDay.Items.Clear();
            //cboUpdateProvince.Items.Clear();
            
            Site thisSite = this.Tag as Site;

            if (thisSite != null)
            {
                // Set the starting text for the textboxes
                txtUpdateLocation.Text = thisSite.SiteName;
                txtUpdateAddress.Text = thisSite.Address;
                txtUpdateCity.Text = thisSite.City;
                txtUpdatePostalCode.Text = thisSite.PostalCode;
                txtUpdatePhone.Text = thisSite.Phone;
                nudUpdateDistanceFromWarehouse.Value = thisSite.DistanceFromWh;
                lblSiteID.Text = thisSite.SiteId.ToString();
                chkLocationActive.Checked = thisSite.Active == 1 ? true : false;

                // Set the combo box starting indices
                cboUpdateCountry.SelectedItem = thisSite.Country;
                cboUpdateDeliveryDay.SelectedItem = thisSite.DayOfWeek;
                cboUpdateLocationType.SelectedItem = thisSite.locationType;
                cboUpdateProvince.SelectedItem = thisSite.ProvinceId;
            } else
            {
                MessageBox.Show("There was a problem getting the site that you specified for updating.", "Please try again");
                this.Close();
            }

            //cboUpdateCountry.DataSource = Enum.GetValues(typeof(Countries));
            //cboUpdateDeliveryDay.DataSource = Enum.GetValues(typeof(DeliveryDate));
            //cboUpdateProvince.DataSource = Enum.GetValues(typeof(Provinces));
        }

        private async void btnSubmitLocationUpdate_Click(object sender, EventArgs e)
        {
            //int distanceFromWh;
            //bool validDistance = int.TryParse(txtUpdateDistanceToWh.Text, out distanceFromWh);
            //if (!validDistance)
            //{
            //    MessageBox.Show("The supplied 'Distance from Warehouse' is invalid", "Invalid distance from Warehouse");
            //    return;
            //}

            if (ValidateInput.IsTextFieldEmpty(txtUpdateLocation))
            {
                MessageBox.Show("The location field is empty", "Location cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtUpdateAddress))
            {
                MessageBox.Show("The supplied address field is empty", "Address cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtUpdateCity))
            {
                MessageBox.Show("The city field is empty", "City cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtUpdatePostalCode))
            {
                MessageBox.Show("The postal code field is empty", "Postal code cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtUpdatePhone))
            {
                MessageBox.Show("The phone number field is empty", "Phone cannot be empty");
                return;
            }

            Site? thisLocation = this.Tag as Site;
            if (thisLocation != null) 
            { 
                thisLocation.SiteName = txtUpdateLocation.Text;
                thisLocation.Address = txtUpdateAddress.Text;
                thisLocation.City = txtUpdateCity.Text;
                thisLocation.ProvinceId = cboUpdateProvince.Text;
                thisLocation.Country = cboUpdateCountry.Text;
                thisLocation.PostalCode = txtUpdatePostalCode.Text;
                thisLocation.Phone = txtUpdatePhone.Text;
                thisLocation.DayOfWeek = cboUpdateDeliveryDay.Text;
                thisLocation.DistanceFromWh = Convert.ToInt32(nudUpdateDistanceFromWarehouse.Value);
                thisLocation.Notes = txtUpdateNotes.Text;
                thisLocation.Active = (sbyte)(chkLocationActive.Checked ? 1 : 0);
                thisLocation.locationType = cboUpdateLocationType.Text;
            }

            Site updatedSite = await _locationController.UpdateLocation(thisLocation);
            if (updatedSite != null)
            {
                this.Close();
            } else
            {
                MessageBox.Show("There was a problem updating the location's data.", "Please try again");
            }
        }

        private void btnExitLocationUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
