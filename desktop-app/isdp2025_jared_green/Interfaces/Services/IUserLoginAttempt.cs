using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface IUserLoginAttempt
    {
        public Task<bool> RecordFailedLoginAttempt(int userID);

        public Task<bool> ResetFailedLoginAttempts(int userID);

        public Task<Employeeloginattempt>? GetUserLoginAttempt(int employeeID);

    }
}
