using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Services
{
    internal class AuthorizationService : IAuthorization
    {
        // Declare the static logger.
        private static readonly NLog.Logger AuthorizationLogger = NLog.LogManager.GetCurrentClassLogger();
        // private readonly BullseyeContext _bullseyeContext;

        public bool ValidatePermissions()
        {
            return true;
        }
    }
}
