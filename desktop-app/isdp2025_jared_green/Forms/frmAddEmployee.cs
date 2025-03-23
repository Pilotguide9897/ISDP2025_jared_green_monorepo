using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
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

namespace idsp2025_jared_green
{
    public partial class frmAddEmployee : Form
    {
        private readonly IPermissionController _permissionsController;

        private readonly ILocationController _locationController;

        private readonly IEmployeeController _employeeController;

        private readonly IAuthenticationController _authenticationController;

        private List<Site> _locations;

        private List<Posn> _positions;
        public frmAddEmployee(IPermissionController permissionController, ILocationController locationController, IEmployeeController employeeController, IAuthenticationController authenticationController)
        {
            _permissionsController = permissionController;
            _locationController = locationController;
            _employeeController = employeeController;
            _authenticationController = authenticationController;
            InitializeComponent();
            // GetPermissions();
        }

        private async void frmAddEmployee_Load(object sender, EventArgs e)
        {
            // ApplyPermissions();
            await GetLocationData();
            await GetPositionData();
            cboPosition.SelectedIndex = 0;
            btnSubmit.Enabled = false;
        }

        private async Task GetPositionData()
        {
            BindingList<Posn> posns = await _permissionsController.GetPermissions();
            if (posns != null && posns.Count > 0)
            {
                _positions = posns.ToList();

                foreach (Posn posn in _positions)
                {
                    cboPosition.Items.Add(posn);
                }
                cboPosition.SelectedIndex = 0;
                PopulateLocationsListbox(cboPosition.SelectedItem as Posn);
            }
        }

        private async Task GetLocationData()
        {
            BindingList<Site> sites = await _locationController.GetBullseyeLocations();
            if (sites != null && sites.Count > 0)
            {
                _locations = sites.ToList();
                //foreach (Site site in sites)
                //{
                //    cboLocation.Items.Add(site);
                //}
            }
        }

        public void ApplyPermissions(List<Posn> employeePositions)
        {
            foreach (Posn position in employeePositions)
            {
                switch (position)
                {
                    //case :

                    //case :

                    //case :

                    default:
                        MessageBox.Show("Error: No employee permissions detected. Closing form");
                        this.Close();
                        break;
                }
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.CheckInput(txtFirstName, lblFirstNameError, 20);
            CheckForErrors();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.CheckInput(txtLastName, lblLastNameError, 20);
            CheckForErrors();
        }

        private void CheckForErrors()
        {
            if (lblFirstNameError.Text == string.Empty && lblLastNameError.Text == string.Empty && txtFirstName.Text.Length > 0 && txtLastName.Text.Length > 0)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPosition.Focused && cboPosition.SelectedIndex > -1)
            {
                PopulateLocationsListbox(cboPosition.SelectedItem as Posn);
            }
        }

        private void PopulateLocationsListbox(Posn position)
        {
            cboLocation.Items.Clear();
            if (_locations != null && _locations.Count > 0)
            {
                foreach (var location in _locations)
                {
                    if (IsValidLocationForPosition(location, position))
                    {
                        cboLocation.Items.Add(location);
                        // Only set the index if there is one or more valid locations.
                        cboLocation.SelectedIndex = 0;
                    }
                }

            }
        }

        private bool IsValidLocationForPosition(Site site, Posn position)
        {
            switch (position.PermissionLevel)
            {
                case "Regional Manager":
                case "Financial Manager":
                    return site.SiteName == "Bullseye Corporate Headquarters";
                case "Warehouse Manager":
                    return site.SiteName == "Warehouse" || site.SiteName == "Warehouse Bay";
                case "Store Manager":
                    return site.SiteName.Contains("Retail");
                case "Administrator":
                    return site.SiteName == "Bullseye Corporate Headquarters";
                case "Delivery":
                    return site.SiteName == "Truck";
                default:
                    return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the data
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = firstName.Substring(0, 1).ToLower() + lastName.ToLower();
            string email = username + "@bullseye.ca";
            string password = "P@ssw0rd-";
            int positionID = (cboPosition.SelectedItem as Posn).PositionId;
            int siteID = (cboLocation.SelectedItem as Site).SiteId;
            sbyte active = 1;
            // await _authenticationController.GenerateKeyAndIV(username);

            await _employeeController.AddEmployee(firstName, lastName, username, email, password, positionID, siteID, active);
            // Persist the data
            await _employeeController.SaveChanges();

            this.Close();
        }

        private void frmAddEmployee_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Provide the employee's first and last names in the textboxes provided. Both must be filled and cannot be longer than 20 characters. Select a position and then a location using the drop down provided. Set whether the new employee is active or not with the 'active' checkbox. When the employee's details are correct, click the create button to submit. Otherwise, click the exit button to cancel the employee creation.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
