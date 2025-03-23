using Azure.Core.GeoJson;
using idsp2025_jared_green.Controllers;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace idsp2025_jared_green.Forms
{
    public partial class frmUpdateEmployee : Form
    {
        private Employee _employee;
        private readonly IEmployeeController _employeeController;
        private readonly IPermissionController _permissionsController;
        private readonly ILocationController _locationController;
        private readonly IAuthenticationController _authenticationController;
        private List<Site> _locations;
        private List<Posn> _positions;
        public frmUpdateEmployee(Employee employee, IEmployeeController employeeController, IPermissionController permissionController, ILocationController locationController, IAuthenticationController authenticationController)
        {
            _employee = employee;
            _employeeController = employeeController;
            _permissionsController = permissionController;
            _locationController = locationController;
            _authenticationController = authenticationController;
            InitializeComponent();
            PopulateFields(_employee);
        }

        private void PopulateFields(Employee employee)
        {
            string email = employee.Email.Split("@")[0];

            lblEmployeeID.Text = employee.EmployeeId.ToString();
            txtUpdateFirstName.Text = employee.FirstName;
            txtUpdateLastName.Text = employee.LastName;
            txtUpdateEmail.Text = email;
            cboUpdatePosition.SelectedValue = employee.Position;
            cboUpdateLocation.SelectedValue = employee.Site;
            chkEditEmployeeActive.Checked = employee.Active == 1 ? true : false;
            chkEditEmployeeLocked.Checked = employee.Locked == 1 ? true : false;
        }

        private async Task GetPositionData()
        {
            BindingList<Posn> posns = await _permissionsController.GetPermissions();
            if (posns != null && posns.Count > 0)
            {
                _positions = posns.ToList();

                foreach (Posn posn in _positions)
                {
                    cboUpdatePosition.Items.Add(posn);
                }
                int startingIndex = cboUpdatePosition.Items.IndexOf(_employee.Position);
                cboUpdatePosition.SelectedIndex = startingIndex;
                PopulateLocationsListbox(cboUpdatePosition.SelectedItem as Posn);
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

        private void PopulateLocationsListbox(Posn position)
        {
            cboUpdateLocation.Items.Clear();
            if (_locations != null && _locations.Count > 0)
            {
                foreach (var location in _locations)
                {
                    if (IsValidLocationForPosition(location, position))
                    {
                        cboUpdateLocation.Items.Add(location);
                        // Only set the index if there is one or more valid locations.
                        cboUpdateLocation.SelectedIndex = 0;
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
                        MessageBox.Show("Error: No permissions detected for updating employees. Closing form");
                        this.Close();
                        break;
                }
            }
        }

        private void txtUpdateFirstName_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.CheckInput(txtUpdateFirstName, lblUpdateFirstNameError, 20);
            if (lblUpdateFirstNameError.Text != string.Empty)
            {
                btnSaveEmployeeUpdates.Enabled = false;
            }
            else
            {
                btnSaveEmployeeUpdates.Enabled = true;
            }
        }

        private void txtUpdateLastName_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.CheckInput(txtUpdateLastName, lblUpdateLastNameError, 20);
            if (lblUpdateLastNameError.Text != string.Empty)
            {
                btnSaveEmployeeUpdates.Enabled = false;
            }
            else
            {
                btnSaveEmployeeUpdates.Enabled = true;
            }
        }

        private void txtUpdateEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateInput.CheckInput(txtUpdateEmail, lblUpdateEmailError, 88);
            if (lblUpdateEmailError.Text != string.Empty)
            {
                btnSaveEmployeeUpdates.Enabled = false;
            }
            else
            {
                btnSaveEmployeeUpdates.Enabled = true;
            }
        }

        private async void btnSaveEmployeeUpdates_Click(object sender, EventArgs e)
        {
            if (lblUpdateFirstNameError.Text == string.Empty && lblUpdateLastNameError.Text == string.Empty && lblUpdateEmailError.Text == string.Empty)
            {

                if (cboUpdatePosition.SelectedIndex != -1 && cboUpdateLocation.SelectedIndex != -1)
                {
                    _employee.FirstName = txtUpdateFirstName.Text;
                    _employee.LastName = txtUpdateLastName.Text;
                    _employee.Username = _employee.FirstName.Substring(0, 1) + _employee.LastName;
                    _employee.Email = txtUpdateEmail.Text;
                    _employee.Position = cboUpdatePosition.SelectedItem as Posn;
                    _employee.Site = cboUpdateLocation.SelectedItem as Site;

                    // Create a new key for the person
                    string decryptedPassword = await _authenticationController.DecodePassword(_employee.Username);
                    // Create a new secret
                    _authenticationController.GenerateKeyAndIV(_employee.Username);
                    // Get the user's new password
                    _employee.Password = await _authenticationController.HashPassword(_employee.Username, decryptedPassword);
                }

                // await _employeeController.UpdateEmployee(_employee);
                await _employeeController.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: First Name, Last Name, and Email must be provided. Please fill out all of the required fields and try again.");
            }
        }

        private void btnExitEmployeeUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmUpdateEmployee_Load(object sender, EventArgs e)
        {
            chkEditEmployeeActive.Checked = _employee.Active == 1 ? true : false;
            chkEditEmployeeLocked.Checked = _employee.Locked == 1 ? true : false;
            chkResetPassword.Checked = false;
            // ApplyPermissions();
            await GetLocationData();
            await GetPositionData();
        }

        private void frmUpdateEmployee_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Update an employee's details in Bullseye's records. Provide the updated username, password, email, position, and location in the appropriate fields. No selection can be left empty. If you wish to reset the user's password to default, check the 'reset password' checkbox. To toggle the employee's active state, set the employee checkbox accordingly (i.e. checked for active, unchecked for inactive). Lock the user's account with the 'account locked' checkbox. Locked accounts will remain active employees, but will not be permitted to log in.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
