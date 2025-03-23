using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idsp2025_jared_green.Forms
{
    public partial class frmResetPassword : Form
    {
        // Fields
        private readonly IAuthenticationController _authenticationController;
        private readonly IEmployeeController _employeeController;
        private readonly string _username;
        private readonly bool _firstTimeLogin;
        private bool passwordChanged = false;

        // private readonly IServiceProvider _serviceProvider;

        //internal frmResetPassword(AuthenticationController authenticationController, IServiceProvider serviceProvider)
        internal frmResetPassword(string username, bool firstTimeLoggingIn)
        {
            _authenticationController = Program._serviceProvider.GetRequiredService<IAuthenticationController>();
            _employeeController = Program._serviceProvider.GetRequiredService<IEmployeeController>();
            _username = username;
            _firstTimeLogin = firstTimeLoggingIn;
            InitializeComponent();
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _username;
            btnExitPasswordReset.Enabled = !_firstTimeLogin;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void btnExitPasswordReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            lblResetPasswordInfo.Text = "";
            if (ValidateInput.ValidatePassword(txtNewPassword.Text) || txtNewPassword.Text == "P@ssw0rd-")
            {
                if (ValidateInput.DoesTextContentMatch(txtNewPassword.Text, txtConfirmPassword.Text))
                {
                    if (_username != string.Empty)
                    {
                        try
                        {
                            //string updatedPassword = await _authenticationController.HashPassword(_username, txtConfirmPassword.Text);
                            Employee emp = await _employeeController.GetEmployeeByUsername(_username);
                            await _employeeController.UpdateEmployeePassword(emp, txtConfirmPassword.Text);
                            passwordChanged = true;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("We are unable to update the password for this account", "Account Error");
                            this.Close();
                        }
                    }
                }
                else
                {
                    lblResetPasswordInfo.Text = "Password Confirmation Must Match";
                }
            }
            else
            {
                lblResetPasswordInfo.Text = "Invalid password.";
            }
        }

        private void txtNewPassword_MouseHover(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '\0';

        }

        private void txtConfirmPassword_MouseHover(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '\0';
        }

        private void txtNewPassword_MouseLeave(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '*';
        }

        private void txtConfirmPassword_MouseLeave(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';
        }

        private void frmResetPassword_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "Reset your password. Bullseye requires all first-time logins to change their password from the default. Later, employees can also submit requests to change their passwords. The entries in the new and confirm password field must both be filled and match. Hover over the field to see the contents.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_firstTimeLogin && passwordChanged == false)
            {
                e.Cancel = true;
            }


        }
    }
}
