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
    public partial class frmAddLocation : Form
    {
        private readonly ILocationController _locationController;
        public frmAddLocation(ILocationController locationController)
        {
            _locationController = locationController;
            InitializeComponent();
        }

        private void frmAddLocation_Load(object sender, EventArgs e)
        {
            //cboCountry.Items.Clear();
            //cboDeliveryDate.Items.Clear();
            //cboProvince.Items.Clear();
            
            // cboCountry.DataSource = Enum.GetValues(typeof(Countries));
            // cboDeliveryDate.DataSource = Enum.GetValues(typeof(DeliveryDate));
            // cboProvince.DataSource = Enum.GetValues(typeof(Provinces));
            txtLocation.Focus();
            cboCountry.SelectedIndex = 0;
            cboDeliveryDate.SelectedIndex = 0;
            cboProvince.SelectedIndex = 3;
            cboSiteType.SelectedIndex = 0;
        }

        private async void btnSubmitItemLocation_Click(object sender, EventArgs e)
        {
            // Check that the distance is an int.
            //int distanceFromWh; 
            //bool validDistance = int.TryParse(txtDistanceFromWh.Text, out distanceFromWh);
            //if (!validDistance)
            //{
            //    MessageBox.Show("The supplied 'Distance from Warehouse' is invalid", "Invalid distance from Warehouse");
            //    return;
            //}

            if (ValidateInput.IsTextFieldEmpty(txtLocation))
            {
                MessageBox.Show("The location field is empty", "Location cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtAddress))
            {
                MessageBox.Show("The supplied address field is empty", "Address cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtCity))
            {
                MessageBox.Show("The city field is empty", "City cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtPostalCode))
            {
                MessageBox.Show("The postal code field is empty", "Postal code cannot be empty");
                return;
            }

            if (ValidateInput.IsTextFieldEmpty(txtPhone))
            {
                MessageBox.Show("The phone number field is empty", "Phone cannot be empty");
                return;
            }

                // Add the values from the form:
                Site newLocation = new Site();
                newLocation.SiteName = txtLocation.Text;
                newLocation.Address = txtAddress.Text;
                newLocation.City = txtCity.Text;
                newLocation.Phone = txtPhone.Text;
                newLocation.PostalCode = txtPostalCode.Text;
                newLocation.ProvinceId = cboProvince.Text;
                newLocation.Country = cboCountry.Text;
                newLocation.DayOfWeek = cboDeliveryDate.Text;
                newLocation.DistanceFromWh = Convert.ToInt32(nudDistanceFromWarehouse.Value);
                newLocation.locationType = cboSiteType.Text;
                newLocation.Notes = txtLocationNotes.Text;
                newLocation.Active = (sbyte)1;

            Site uploadedSite = await _locationController.AddLocation(newLocation);
            if (uploadedSite != null)
            {
                this.Close();
            } else
            {
                MessageBox.Show("There was an error adding the new site.", "Error adding site");
            }

        }

        private void btnCancelLocationUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
