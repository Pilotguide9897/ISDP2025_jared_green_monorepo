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
        public Task<Object> GetEmployeeByEmail(string email);

        public Task<Object> GetEmployeeByUsername(string username);
    }
}
