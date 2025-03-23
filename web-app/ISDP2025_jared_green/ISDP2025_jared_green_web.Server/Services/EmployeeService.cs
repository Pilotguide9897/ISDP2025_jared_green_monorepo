using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Services
{
    internal class EmployeeService : IEmployees
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly BullseyeContext _bullseyeContext;

        public EmployeeService(ILogger<EmployeeService> logger, BullseyeContext bullseyeContext)
        {
            _bullseyeContext = bullseyeContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Employee?> GetEmployeeByEmail(string email)
        {
            try
            {
                var employee = await (from e in _bullseyeContext.Employees
                                      where e.Email == email
                                      select e).Include(j => j.Employeeroles).ThenInclude(k => k.Position).FirstOrDefaultAsync();

                return employee;
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError(msqlEx, "MySQL database error while fetching employee data.");
                throw;
            }
            catch (TimeoutException toEx)
            {
                _logger.LogError(toEx, "Timeout error while fetching employee data.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching employee data.");
                throw;
            }
        }

        public async Task<Employee?> GetEmployeeByUsername(string username)
        {
            try
            {
                var employee = await (from e in _bullseyeContext.Employees
                                      where e.Username == username
                                      select e).Include(s => s.Site).FirstOrDefaultAsync();

                return employee;
            }
            catch (MySqlException msqlEx)
            {
                _logger.LogError(msqlEx, "MySQL database error while fetching employee data.");
                throw;
            }
            catch (TimeoutException toEx)
            {

                _logger.LogError(toEx, "Timeout error while fetching employee data.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching employee data.");
                throw;
            }
        }
    }
}
