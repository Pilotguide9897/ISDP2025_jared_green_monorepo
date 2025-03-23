using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    internal class AuthorizationController : IAuthorizationController
    {
        // Field to hold the authorization service class
        private readonly IAuthorization _authorizationService;

        // Constructor
        public AuthorizationController(IAuthorization authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // Controller Methods
    }
}
