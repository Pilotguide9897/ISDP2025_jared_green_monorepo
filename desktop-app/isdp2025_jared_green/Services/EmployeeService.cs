using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace idsp2025_jared_green.Services
{
    internal class EmployeeService : IEmployees
    {
        // Declare the static logger.
        private static readonly NLog.Logger EmployeeLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly BullseyeContext _bullseyeContext;
        private readonly IEncryption _encryptionService;

        public EmployeeService(IEncryption encryptionService, BullseyeContext bullseyeContext) 
        {
            _encryptionService = encryptionService;
            _bullseyeContext = bullseyeContext;
        }

        public async Task<BindingList<Employee>?> GetAllEmployees()
        {
            try
            {

                var employees = await (from e in _bullseyeContext.Employees
                                       select e).Include(l => l.Site).Include(p => p.Position).Include(ep => ep.Employeeroles).ToListAsync();

                //foreach (var employee in employees)
                //{
                //    foreach (var item in employee.Employeeroles) {

                //        MessageBox.Show(item.Position.ToString());
                //    }
                //}

                var bindingList = new BindingList<Employee>(employees);

                return bindingList;
               
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeLogger.Error(msqlEx, "");
                return new BindingList<Employee>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeLogger.Error(toEx, "");
                return new BindingList<Employee>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the employee data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeLogger.Error(ex, "");
                return new BindingList<Employee>();
            }
        }

        public async Task<Employee?> GetEmployeeByID(int employeeID)
        {
            try
            {

                var employee = await _bullseyeContext.Employees
                  .Include(e => e.Site)
                  .Where(e => e.EmployeeId == employeeID)
                  .FirstOrDefaultAsync();

                return employee;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show(
                    "A database error occurred while retrieving employee data. Please check your connection and try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                EmployeeLogger.Error(msqlEx, "MySQL database error while fetching employee data.");
                return new Employee();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show(
                    "The request timed out while retrieving employee data. Please try again later.",
                    "Timeout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                EmployeeLogger.Error(toEx, "Timeout error while fetching employee data.");
                return new Employee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while fetching the employee data. Please contact support if the problem persists.",
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                EmployeeLogger.Error(ex, "Unexpected error while fetching employee data.");
                return new Employee();
            }
        }

        public async Task<Employee?> GetEmployeeByUsername(string username) 
        {
            try
            {
                var employee = await (from e in _bullseyeContext.Employees where e.Username == username
                                   select e).Include(s => s.Site).FirstOrDefaultAsync();

                return  employee;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show(
                    "A database error occurred while retrieving employee data. Please check your connection and try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                EmployeeLogger.Error(msqlEx, "MySQL database error while fetching employee data.");
                return new Employee();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show(
                    "The request timed out while retrieving employee data. Please try again later.",
                    "Timeout Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                EmployeeLogger.Error(toEx, "Timeout error while fetching employee data.");
                return new Employee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while fetching the employee data. Please contact support if the problem persists.",
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                EmployeeLogger.Error(ex, "Unexpected error while fetching employee data.");
                return new Employee();
            }
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            Employee emp = await GenerateUniqueUsername(employee).ConfigureAwait(false);

            bool success = await _encryptionService.GenerateKeyAndIV(employee.Username);
            var keyAndIv = await _encryptionService.RetrieveKeyAndIV(employee.Username);

            if (keyAndIv != null)
            {
                byte[] k = keyAndIv.Value.Item1;
                byte[] Iv = keyAndIv.Value.Item2;
                byte[] encryptedPass = _encryptionService.HashPassword("P@ssw0rd-", k, Iv);

                employee.Password = Convert.ToBase64String(encryptedPass);
            }

            if (success)
            {
                employee.Username = emp.Username;
                employee.Email = emp.Email;

                try
                {
                    await _bullseyeContext.Employees.AddAsync(employee);
                    await _bullseyeContext.SaveChangesAsync();

                    return true;
                }
                // Add any other type of exceptions that I explicitly want to catch.
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        private async Task<Employee> GenerateUniqueUsername(Employee employee)
        {
            string def = employee.Username;
            string username = employee.Username;
            int counter = 0;

            while (await GetEmployeeByUsername(username).ConfigureAwait(false) != null)
            {
                counter++;
                username = def + counter.ToString("D2");
            }
            if (counter > 0)
            {
                employee.Username = def + counter.ToString("D2");
                employee.Email = employee.Username + "@bullseye.ca";

            }

            return employee;
        }

        //public async Task<bool> UpdateEmployee(Employee employee, Employee newData)
        public async Task<bool> UpdateEmployee(Employee employee, bool usernameChanged)
        {
            Employee emp;
            try
            {
                if (usernameChanged) {
                    emp = await GenerateUniqueUsername(employee).ConfigureAwait(false);
                    employee.Username = emp.Username;
                    employee.Email = emp.Email;
                }

                if (await _encryptionService.RetrieveKeyAndIV(employee.Username) == null) { 
                    await _encryptionService.GenerateKeyAndIV(employee.Username);
                }

                var keyAndIv = await _encryptionService.RetrieveKeyAndIV(employee.Username);

                if (keyAndIv != null)
                {
                    byte[] k = keyAndIv.Value.Item1;
                    byte[] Iv = keyAndIv.Value.Item2;
                    byte[] encryptedPass = _encryptionService.HashPassword(employee.Password, k, Iv);

                    employee.Password = Convert.ToBase64String(encryptedPass);
                }

                    _bullseyeContext.Update(employee);
                // Persist the changes
                await _bullseyeContext.SaveChangesAsync();

                return true;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            try
            {
                employee.Active = 0;
                await _bullseyeContext.SaveChangesAsync();

                return true;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _bullseyeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
