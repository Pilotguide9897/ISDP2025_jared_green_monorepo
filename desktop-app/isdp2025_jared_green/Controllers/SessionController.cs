using Azure.Core;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Forms;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Interfaces.Controllers;

namespace idsp2025_jared_green.Controllers
{
    internal class SessionController : ISessionManager

    {
        private string? _accessToken;
        private string? _renewalToken;
        private System.Timers.Timer? _inactivityTimer;
        public event EventHandler SessionExpired;

        public readonly IAuthentication _authenticationService;
        public readonly IPermissions _permissionService;
        public readonly IJsonWebToken _jsonWebTokenService;
        public readonly IEmployeeController _employeeController;
        public string? _employeeUsername;
        public string? _employeeSiteNumber;

        public SessionController(IAuthentication authenticationService, IPermissions permissionService, IJsonWebToken jsonWebTokenService, IEmployeeController employeeController)
        {
            _authenticationService = authenticationService;
            _permissionService = permissionService;
            _jsonWebTokenService = jsonWebTokenService;
            _employeeController = employeeController;
        }


        public async Task<bool> Login(string username, string password)
        {
            if (await _authenticationService.AttemptLogin(username, password))
            {
                Employee emp = await _employeeController.GetEmployeeByUsername(username);
                BindingList<Posn> employeeRoles = await _permissionService.GetEmployeesRolesByUsername(username);
                // GenerateJWToken(username, employeeRoles.ToList());
                //GenerateJWTokenWithLocation(username, employeeRoles.ToList(), emp.SiteId.ToString());
                GenerateJWTokenWithLocation(username, employeeRoles.ToList(), emp.Site.SiteName.ToString());

                SetInactivityTimer();

                return true;

            } else
            {
                return false;
            }
        }

        public bool GenerateJWToken(string username, List<Posn> employeeRoles, Site site)
        {
            try
            {
                _accessToken =  _jsonWebTokenService.GenerateToken(username, employeeRoles, site.SiteName);
                _renewalToken = _jsonWebTokenService.GenerateRefreshToken();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GenerateJWTokenWithLocation(string username, List<Posn> employeeRoles, string location)
        {
            try
            {
                //_accessToken = _jsonWebTokenService.GenerateToken(username, employeeRoles);
                _accessToken = _jsonWebTokenService.GenerateToken(username, employeeRoles, location);
                _renewalToken = _jsonWebTokenService.GenerateRefreshToken();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckLoggedIn(string accessToken)
        {
            // Validates the access token
            try
            {
                return (_jsonWebTokenService.ValidateToken(accessToken) == null);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> GetPermissionsFromToken()
        {   
            if( _accessToken != null )
            {
                return _jsonWebTokenService.GetRolesFromToken(_accessToken);
            } else
            {
                return new List<string>();
            }

        }

        public List<string> ExtractUsernameAndLocation()
        {
            return _jsonWebTokenService.ExtractUserInfoFromToken(_accessToken);
        }

        public bool RenewJWToken(string accessToken, string renewalToken)
        {
            try
            {
                // Renew the web token.
                ClaimsPrincipal principal = _jsonWebTokenService.GetPrincipalFromExpiredToken(accessToken);
                accessToken = _jsonWebTokenService.RefreshToken(principal.Claims);
                return true;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Logout()
        {
            // invalidate the web token.
            try
            {
                _accessToken = null;
                _renewalToken = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async void SetTokenRefreshTimer()
        {
                await Task.Delay(600000);
                ClaimsPrincipal claimsPrincipal = _jsonWebTokenService.GetPrincipalFromExpiredToken(_accessToken);
                _jsonWebTokenService.RefreshToken(claimsPrincipal.Claims);
        }

        public void SetInactivityTimer()
        {
            _inactivityTimer = new System.Timers.Timer();
            _inactivityTimer.Interval = 600000; // Set for 10 minutes
            _inactivityTimer.Elapsed += InactivityTimer_Elapsed;
            _inactivityTimer.Start();
        }

        private void InactivityTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            frmRemainLoggedIn frmRemainLoggedIn = new frmRemainLoggedIn();
            _inactivityTimer?.Stop();
            if (frmRemainLoggedIn.ShowDialog() == DialogResult.OK)
            {
                //_inactivityTimer.Stop();
                SetInactivityTimer();
            }
            else
            {

                //_inactivityTimer.Stop();
                Logout();
                OnSessionExpired(EventArgs.Empty);
            }
        }

        protected virtual void OnSessionExpired(EventArgs e)
        {
            SessionExpired?.Invoke(this, e);
        }

        public void ResetInactivityTimer()
        {
            _inactivityTimer.Stop();
            _inactivityTimer.Start();
        }
    }
}
