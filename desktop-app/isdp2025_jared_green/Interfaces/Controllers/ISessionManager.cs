using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface ISessionManager
    {
        public event EventHandler SessionExpired;

        Task<bool> Login(string username, string password);

        bool GenerateJWToken(string username, List<Posn> employeeRoles, Site site);

        bool CheckLoggedIn(string accessToken);

        bool RenewJWToken(string accessToken, string renewalToken);

        bool Logout();

        public List<string> GetPermissionsFromToken();

        public List<string> ExtractUsernameAndLocation();

        public void ResetInactivityTimer();
    }
}
