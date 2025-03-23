using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    internal interface IAuthorization
    {
        public bool ValidatePermissions();
    }
}
