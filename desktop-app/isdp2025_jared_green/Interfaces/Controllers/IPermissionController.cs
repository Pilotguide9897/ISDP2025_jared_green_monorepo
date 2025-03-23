using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IPermissionController
    {
        public Task<BindingList<Posn>> GetPermissions();

        public Task<bool> SetPermissions(Employee emp, List<Posn> roles);
    }
}
