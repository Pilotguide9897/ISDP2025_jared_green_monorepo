using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IDashboardController
    {
        public Task<BindingList<Employee>> GetEmployees();

        public Task<BindingList<Item>> GetItems();

        public Task<BindingList<Posn>> GetPositions();

        public Task<BindingList<Posn>> GetEmployeeRoles(string username);

        public Task<bool> DeleteEmployee(Employee employee);



    }
}
