using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Services
{
    internal class PermissionService : IPermissions
    {
        // Declare the static logger.
        private static readonly NLog.Logger PermissionLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly BullseyeContext _bullseyeContext;

        public PermissionService(BullseyeContext context)
        {
            _bullseyeContext = context;
        }

        public async Task<BindingList<Posn>> GetAllPositions()
        {
            try
            {

                //var roles = await (from rl in _bullseyeContext.Posns
                //            select rl).ToListAsync();
                var roles = await _bullseyeContext.Posns.ToListAsync();

                var bindingList = new BindingList<Posn>(roles);

                    return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
                return new BindingList<Posn>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
                return new BindingList<Posn>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the position data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
                return new BindingList<Posn>();
            }
        }

        public async Task AddPermission(Employeerole employeeRole)
        {
            try
            {
                // Add the new Employeerole instance to the context
                await _bullseyeContext.Employeeroles.AddAsync(employeeRole);

                // Save changes to the database
                await _bullseyeContext.SaveChangesAsync();
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred adding the position data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
            }
        }


        public async Task<BindingList<Employeerole>> GetEmployeesRoles(int userID)
        {
            try
            {
                await using (var context = new BullseyeContext())
                {
                    //var employeeRoles = (from er in context.Employeeroles
                    //                    where er.EmployeeId == userID
                    //                    where er.Active == 1
                    //                    select er).ToList();
                    //var employeeRoles = (from er in context.Employeeroles
                    //                     where er.EmployeeId == userID
                    //                     where er.Active == 1
                    //                     select er).Include(e => e.Position).ToList();
                    var employeeRoles = (from er in context.Employeeroles
                                         where er.EmployeeId == userID
                                         select er).Include(e => e.Position).ToList();

                    var bindingList = new BindingList<Employeerole>(employeeRoles);

                    return bindingList;
                }
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
                return new BindingList<Employeerole>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
                return new BindingList<Employeerole>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the employee role data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
                return new BindingList<Employeerole>();
            }
        }

        public async Task<BindingList<Posn>> GetEmployeesRolesByUsername(string username)
        {
            try
            {
               await using (var context = new BullseyeContext())
                {
                    var employeePositions = (from e in context.Employees
                                        join er in context.Employeeroles on e.EmployeeId equals er.EmployeeId
                                        join p in context.Posns on er.PositionId equals p.PositionId
                                        where e.Username == username
                                        select p).ToList();

                    var bindingList = new BindingList<Posn>(employeePositions);

                    return bindingList;
                }
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
                return new BindingList<Posn>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
                return new BindingList<Posn>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the employee role data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
                return new BindingList<Posn>();
            }
        }

        public async Task<Posn> GetUserPosition(int userID)
        {
            try
            {
                var userPosition = await (from emp in _bullseyeContext.Employees
                                    where emp.EmployeeId == userID
                                    select emp.Position).FirstOrDefaultAsync();

                if (userPosition != null)
                {
                    return userPosition;
                }
                else
                {
                    return new Posn();
                }
                    

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
                return new Posn();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
                return new Posn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the user's position data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
                return new Posn();
            }
        }

        public async Task<Posn> GetRole(int roleID)
        {
            try
            {
                var role = await (from posn in _bullseyeContext.Posns
                            where posn.PositionId == roleID
                            select posn).FirstOrDefaultAsync();


                if (role != null)
                {
                    return role;
                }
                else
                {
                    return new Posn();
                }

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
                return new Posn();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
                return new Posn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the individual position data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
                return new Posn();
            }
        }

        public async Task UpdatePermission(IEnumerable<Employeerole> employeeRoles)
        {
            try
            {

                _bullseyeContext.Employeeroles.UpdateRange(employeeRoles); // Batch update
                await _bullseyeContext.SaveChangesAsync();

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the permission data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
            }
        }

        public Task UpdatePermission(BindingList<Employeerole> employeeRoles)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePermissions(IEnumerable<Employeerole> employeeRoles)
        {
            try
            {
                foreach (var updatedRole in employeeRoles)
                {
                    // Check if the entity is already being tracked
                    var existingRole = _bullseyeContext.Employeeroles.Local
                        .FirstOrDefault(e => e.EmployeeRoleId == updatedRole.EmployeeRoleId);

                    if (existingRole != null)
                    {
                        // Update the existing entity
                        _bullseyeContext.Entry(existingRole).CurrentValues.SetValues(updatedRole);
                    }
                    else
                    {
                        // Attach the entity if not already tracked
                        _bullseyeContext.Employeeroles.Attach(updatedRole);
                        _bullseyeContext.Entry(updatedRole).State = EntityState.Modified;
                    }
                }

                // Save changes
                await _bullseyeContext.SaveChangesAsync();
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(msqlEx, "");
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(toEx, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the permission data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PermissionLogger.Error(ex, "");
            }
        }
    }
}
