using ISDP2025_jared_green_web.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface IEmployees
    {
        public Task<Employee?> GetEmployeeByEmail(string email);

        public Task<Employee?> GetEmployeeByUsername(string username);
    }
}
