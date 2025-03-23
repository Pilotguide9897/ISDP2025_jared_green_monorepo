using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface IPermissions
    {
        public Task<BindingList<Posn>> GetAllPositions();

        public Task<BindingList<Employeerole>> GetEmployeesRoles(int userID);

        public Task<BindingList<Posn>> GetEmployeesRolesByUsername(string username);

        public Task<Posn> GetUserPosition(int userID);

        public Task<Posn> GetRole(int roleID);

        public Task AddPermission(Employeerole employeeRole);

        // public Task UpdatePermission(Employeerole employeeRole);

        public Task UpdatePermission(BindingList<Employeerole> employeeRoles);
        Task UpdatePermissions(IEnumerable<Employeerole> employeeRoles);
    }
}
