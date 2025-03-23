using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    public class LoginAttemptController : ILoginAttemptController
    {
        private readonly IUserLoginAttempt _loginAttemptService;
        public LoginAttemptController() 
        {
        }

        public async Task<bool> ResetLoginAttempts(int employeeID)
        {
           return await _loginAttemptService.ResetFailedLoginAttempts(employeeID);
        }

        public async Task<bool> IncrementLoginFailures(int employeeID)
        {
            return await _loginAttemptService.RecordFailedLoginAttempt(employeeID);
        }
    }
}
