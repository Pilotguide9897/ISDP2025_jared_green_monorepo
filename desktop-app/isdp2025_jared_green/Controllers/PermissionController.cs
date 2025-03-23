using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    public class PermissionController : IPermissionController
    {
        // Field to hold the permissions service class
        private readonly IPermissions _permissionService;

        // Constructor
        public PermissionController(IPermissions permissionService)
        {
            _permissionService = permissionService;
        }

        // Controller Methods
        public async Task<BindingList<Posn>> GetPermissions()
        {
            // Error Handling Goes Here:
            try
            {
                return await _permissionService.GetAllPositions();
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return new BindingList<Posn>();
            }

        }

        public async Task<bool> SetPermissions(Employee emp, List<Posn> roles)
        {
            // 1. Reset the user's permissions
            IEnumerable<Employeerole> employeeRoles = await _permissionService.GetEmployeesRoles(emp.EmployeeId);
            // bool permissionsHaveChanged = false;
            foreach (Employeerole employeeRole in employeeRoles)
            {
                // Deactivate existing roles not in the provided list
                if (!roles.Any(role => role.PermissionLevel == employeeRole.Position.PermissionLevel))
                {
                    if (employeeRole.Active != 0) // Only update if it is actually changing
                    {
                        employeeRole.Active = 0;
                        //await _permissionService.UpdatePermission(employeeRole); // Explicitly update the database
                    }
                }
                else
                {
                    if (employeeRole.Active != 1) // Only update if it is actually changing
                    {
                        employeeRole.Active = 1;
                        //await _permissionService.UpdatePermission(employeeRole);
                    }
                }
            }
                // await _permissionService.UpdatePermissions(employeeRoles);
            // 2.Add back the selected permissions only if they do not already exist
            foreach (var role in roles)
            {

                var existingRole = employeeRoles.FirstOrDefault(er => er.PositionId == role.PositionId);

                if (existingRole != null)
                {
                    if (existingRole.Active == 0)
                    {
                        existingRole.Active = 1;
                    }
                } else
                {
                    Employeerole newEmployeeRole = new Employeerole
                    {
                        EmployeeId = emp.EmployeeId,
                        PositionId = role.PositionId,
                        Active = 1
                    };

                    // Add the new employee role
                    await _permissionService.AddPermission(newEmployeeRole);
                }

                //if (!employeeRoles.Any(er => er.Position.PermissionLevel == role.PermissionLevel))
                //{
                //    // Create a new Employeerole instance and set its properties
                //    Employeerole newEmployeeRole = new Employeerole
                //    {
                //        EmployeeId = emp.EmployeeId,
                //        PositionId = role.PositionId,
                //        Active = 1
                //    };

                //    // Add the new employee role
                //    await _permissionService.AddPermission(newEmployeeRole);


                
            }
            await _permissionService.UpdatePermissions(employeeRoles);



            //foreach (var role in roles)
            //{
            //    var existingRole = employeeRoles.FirstOrDefault(er => er.PositionId == role.PositionId);

            //    if (existingRole != null)
            //    {
            //        // If role exists but is inactive, reactivate it
            //        if (existingRole.Active == 0)
            //        {
            //            existingRole.Active = 1;
            //            await _permissionService.UpdatePermission(existingRole(BindingList<Employeerole>);
            //        }
            //    }
            //    else
            //    {
            //        // Otherwise, create a new entry
            //        Employeerole newEmployeeRole = new Employeerole
            //        {
            //            EmployeeId = emp.EmployeeId,
            //            PositionId = role.PositionId,
            //            Active = 1
            //        };

            //        await _permissionService.AddPermission(newEmployeeRole);
            //    }
            return true;
        }
    }
}
