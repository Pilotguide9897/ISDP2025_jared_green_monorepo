using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Forms;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace idsp2025_jared_green
{
    public partial class frmLogin : Form
    {
        // private readonly IAuthorizationController _authorizationController;
        // internal frmLogin(AuthorizationController authorizationController)
        private readonly ISessionManager _sessionManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthenticationController _authenticationController;
        private readonly IEmployeeController _employeeController;
        private readonly IUserLoginAttempt _loginAttemptService;
        // public frmLogin(IAuthorizationController authorizationController)
        public frmLogin(ISessionManager sessionManager, IServiceProvider serviceProvider, IAuthenticationController authenticationController, IEmployeeController employeeController, IUserLoginAttempt loginAttemptService)
        {
            // _authorizationController = authorizationController;
            //_authorizationController = Program._serviceProvider.GetRequiredService<AuthorizationController>();
            _employeeController = employeeController;
            _loginAttemptService = loginAttemptService;
            _authenticationController = authenticationController;
            _sessionManager = sessionManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btnExitSignin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSignin_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            if (!ValidateInput.IsTextFieldEmpty(txtUsername))
            {
                if (!ValidateInput.IsTextFieldEmpty(txtPassword))
                {
                    // Check if the user is inactive or locked.
                    Employee? employee = null;
                    try
                    {
                        MessageBox.Show("Please be patient as we verify your credentials", "Logging In");
                        employee = await _employeeController.GetEmployeeByUsername(txtUsername.Text);
                        Employeeloginattempt ela = await _loginAttemptService.GetUserLoginAttempt(employee.EmployeeId);
                    } catch(Exception ex)
                    {
                        MessageBox.Show("There was a problem verifying your identity", "Identity Error");
                    }

                    //MessageBox.Show("This is outside: " + employee.Locked.ToString());
                    //MessageBox.Show("This is outside -  Employee Login Attempts: " + ela.SubsequentFailedAttempt.ToString());
                    if (employee == null) 
                    {
                        MessageBox.Show("Unable to log in.", "Login failed");
                        return;
                    }

                    if (employee.Locked == 1)
                    {
                        MessageBox.Show("Your account has been locked because of too many incorrect login attempts. Please contact your administrator at 'admin@bullseye.ca' for assistance.", "Account Locked");
                        return;
                    }

                    if (employee.Active == 0) 
                    {
                        MessageBox.Show("Invalid username and/or password. Please contact your administrator at 'admin@bullseye.ca' for assistance.", "Account Inactive");
                        return;
                    }


                    if (await _sessionManager.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                    {
                        await _loginAttemptService.ResetFailedLoginAttempts(employee.EmployeeId);
                        // If the password is default, prompt the user to reset it:
                        bool result = await _authenticationController.HashPassword(txtUsername.Text, txtPassword.Text) == await _authenticationController.GetDefaultPassword(txtUsername.Text);
                        // MessageBox.Show(await _authenticationController.HashPassword(txtUsername.Text, txtPassword.Text));
                        // MessageBox.Show(await _authenticationController.GetDefaultPassword(txtUsername.Text));
                        if (result)
                        {
                            frmResetPassword frmResetPassword = new frmResetPassword(txtUsername.Text, true);
                            frmResetPassword.ShowDialog();
                        }
                        OpenDashboard();
                    }
                    else
                    {
                        await _loginAttemptService.RecordFailedLoginAttempt(employee.EmployeeId);
                        employee = await _employeeController.GetEmployeeByUsername(txtUsername.Text);
                        // MessageBox.Show("This is inside the failed attempt: " + employee.Locked.ToString());
                        // MessageBox.Show("This is Inside -  Employee Login Attempts: " + ela.SubsequentFailedAttempt.ToString());
                        MessageBox.Show("Please try logging in again.", "Unable to log in");
                        return;
                    }

                    ClearForm();
                }
                else
                {
                    lblInfo.Text = "Please provide a password";
                }
            }
            else
            {
                lblInfo.Text = "Please provide a username";
            }
        }

        private void ClearForm()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            lblInfo.Text = "";
        }

        private void OpenDashboard()
        {
            // Resolve the necessary dependencies
            var dashboardController = _serviceProvider.GetRequiredService<IDashboardController>();
            var employeeController = _serviceProvider.GetRequiredService<IEmployeeController>();
            var permissionController = _serviceProvider.GetService<IPermissionController>();
            var authenticationController = _serviceProvider.GetRequiredService<IAuthenticationController>();
            var authenticationService = _serviceProvider.GetRequiredService<IAuthentication>();
            var transactionController = _serviceProvider.GetRequiredService<ITransactionController>();
            var inventoryController = _serviceProvider.GetRequiredService<IInventoryController>();
            var locationController = _serviceProvider.GetRequiredService<ILocationController>();
            var supplierController = _serviceProvider.GetRequiredService<ISupplierController>();

            // Create an instance of frmDashboard with the resolved dependencies
            // var dashboardForm = new frmDashboard(dashboardController, _sessionManager, permissionController, authenticationService);
            var dashboardForm = new frmDashboard(dashboardController, _serviceProvider, _sessionManager, permissionController, locationController,  transactionController, inventoryController, supplierController);

            // Show the dashboard
            dashboardForm.Show();

        }

        private async void lnkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ClearForm();
            // If no username is provided, ask them to do so before proceeding.
            if (ValidateInput.IsTextFieldEmpty(txtUsername))
            {
                lblInfo.Text = "Please provide a username before clicking the password reset link";
            }
            else
            {
                Employee employee = await _employeeController.GetEmployeeByUsername(txtUsername.Text);

                if (employee == null)
                {
                    MessageBox.Show("Error: Please contact your Administrator for support.", "Unable to reset password");
                }
                else
                {
                    if (employee.Locked == 1)
                    {
                        MessageBox.Show("You account has been locked because of too many incorrect login attempts. Please contact your Administrator at admin@bullseye.ca for assistance.");
                        return;
                    }
                    else if (employee.Active == 0)
                    {
                        MessageBox.Show("Unable to log in, please contact your administrator at 'admin@bullseye.ca' for assistance.", "Error");
                        return;
                    }
                    // Create an instance of the password reset form

                    frmResetPassword passwordResetForm = new frmResetPassword(txtUsername.Text, false);

                    // Pass the logging-in user's username before opening the form
                    //passwordResetForm.Tag = txtUsername.Text;
                    passwordResetForm.ShowDialog();
                    lblInfo.Text = "";
                }
            }
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtPassword_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Enter your company-issued username and password and click the 'sign-in' button to proceed. Hover your mouse over the password field to reveal it as plain text. If you have forgotten your password, type your username in the 'username' field and click the 'Forgot Password?' link.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
