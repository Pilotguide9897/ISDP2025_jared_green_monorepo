using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace idsp2025_jared_green.Controllers
{
    internal class EmployeeController : IEmployeeController
    {
        // Field to hold the employees service class
        private readonly IEmployees _employeeService;

        // Constructor
        public EmployeeController(IEmployees employeeService)
        {
            _employeeService = employeeService;
        }

        // Controller Methods
        public async Task<bool> AddEmployee(string firstName, string lastName, string username, string email, string password, int positionID, int siteID, sbyte active)
        {
            // Create a new user object
            Employee newEmployee = new Employee();
            newEmployee.FirstName = firstName;
            newEmployee.LastName = lastName;
            newEmployee.Username = username;
            newEmployee.Email = email;
            newEmployee.Password = password;
            newEmployee.PositionId = positionID;
            newEmployee.SiteId = siteID;
            newEmployee.Active = active;

            return await _employeeService.AddEmployee(newEmployee);
        }

        public async Task SaveChanges()
        {
            await _employeeService.SaveChanges();
        }

        public async Task<bool> UpdateEmployee(Employee employee, string firstName, string lastName, string username, string email, bool resetPassword, int positionID, int siteID, sbyte active, sbyte locked)
        {   
            bool usernameUpdated = false;
            if (employee.Username != username) 
            {
                usernameUpdated = true;
            }

            // Update Employee Information
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Username = username;
            employee.Email = email;
            if (resetPassword)
            {
                employee.Password = "P@ssw0rd-";
            }
            employee.PositionId = positionID;
            employee.SiteId = siteID;
            employee.Active = active;
            employee.Locked = locked;

            return await _employeeService.UpdateEmployee(employee, usernameUpdated);
        }

        public async Task<bool> UpdateEmployeePassword(Employee employee, string password)
        {

            // Update Employee Information
            employee.Password = password;

            return await _employeeService.UpdateEmployee(employee, false);
        }

        public async Task<Employee?> GetEmployeeByUsername(string username)
        {
            return await _employeeService.GetEmployeeByUsername(username);
        }

    }
}
