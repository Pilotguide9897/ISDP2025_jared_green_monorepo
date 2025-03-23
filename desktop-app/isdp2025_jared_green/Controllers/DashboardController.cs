using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    internal class DashboardController : IDashboardController
    {
        // Dependency Injections for the Controllers
        private readonly IEmployees _employeeService;
        private readonly IItems _itemService;
        private readonly IPermissions _permissionService;
        private readonly IInventory _inventoryService;

        public DashboardController(IEmployees employeeService, IItems itemService, IPermissions permissionService, IInventory inventoryService) 
        {
            _employeeService = employeeService;
            _itemService = itemService;
            _permissionService = permissionService;
            _inventoryService = inventoryService;
        }

        /*---  Methods for Fetching Data  ---*/

        public async Task<BindingList<Employee>> GetEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        public async Task<BindingList<Item>> GetItems()
        {
            return await _itemService.GetAllItems();
        }

        public async Task<BindingList<Posn>> GetPositions()
        {
            return await _permissionService.GetAllPositions();

        }

        public async Task<BindingList<Posn>> GetEmployeeRoles(string username)
        {
            return await _permissionService.GetEmployeesRolesByUsername(username);
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            employee.Active = 0;
            return await _employeeService.SaveChanges();
        }

    }
}
