using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    internal interface IEmployees
    {
        public Task<BindingList<Employee>?> GetAllEmployees();
        public Task<Employee?> GetEmployeeByID(int id);
        public Task<Employee?> GetEmployeeByUsername(string username);

        public Task<bool> AddEmployee(Employee employee);

        public Task<bool> UpdateEmployee(Employee employee, bool usernameChanged);

        public Task<bool> DeleteEmployee(Employee employee);

        public Task<bool> SaveChanges();
    }
}
