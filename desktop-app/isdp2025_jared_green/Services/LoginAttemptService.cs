using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Services
{
    internal class LoginAttemptService : IUserLoginAttempt
    {
        private readonly BullseyeContext _bullseyeContext;

        public LoginAttemptService(BullseyeContext context)
        {
            _bullseyeContext = context;
        }

        public async Task<bool> CheckIfAccountLocked(string employeeUsername) {

            var employee = await (from emp in _bullseyeContext.Employees
                            where emp.Username == employeeUsername
                            select emp.Locked).FirstOrDefaultAsync();

            if (employee != null)
            {
                if (employee != 0) 
                { 
                    return true; 
                }
                else 
                { 
                    return false; 
                }

            } else
            {
                return false;
            }
            
        }

        public async Task<bool> RecordFailedLoginAttempt(int employeeID) {
            
            try
            {
                    // Employeeloginattempt loginAttempt = context.Employeeloginattempt.FirstOrDefault(la => la.EmployeeUsername == employeeUsername);
                    var loginAttempt = await GetUserLoginAttempt(employeeID);
                    if (loginAttempt != null)
                    {
                        loginAttempt.SubsequentFailedAttempt++;
                        loginAttempt.LastFailedAttempt = DateTime.UtcNow;
                    }

                    if (loginAttempt.SubsequentFailedAttempt >= 3)
                    {
                        Employee employee = _bullseyeContext.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeID);
                        employee.Locked = 1;
                        _bullseyeContext.Update(employee);
                    }
                    _bullseyeContext.Update(loginAttempt);
                    await _bullseyeContext.SaveChangesAsync();
                    return true;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> ResetFailedLoginAttempts(int employeeID) {

            try
            {
                    // Employeeloginattempt loginAttempt = context.Employeeloginattempt.FirstOrDefault(la => la.EmployeeUsername == employeeUsername);
                    Employeeloginattempt loginAttempt = await GetUserLoginAttempt(employeeID);
                    if (loginAttempt != null)
                    {
                        loginAttempt.SubsequentFailedAttempt = 0;
                        _bullseyeContext.Update(loginAttempt);
                        await _bullseyeContext.SaveChangesAsync();
                        
                    }
                        return true;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Employeeloginattempt>? GetUserLoginAttempt(int employeeID) {

            try
            {
                Employeeloginattempt? loginAttempt = await _bullseyeContext.Userloginattempt.FirstOrDefaultAsync(la => la.EmployeeID == employeeID);
                return loginAttempt;
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
