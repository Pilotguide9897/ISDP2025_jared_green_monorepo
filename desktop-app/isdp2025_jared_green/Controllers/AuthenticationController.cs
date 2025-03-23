using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Controllers
{
    internal class AuthenticationController : IAuthenticationController
    {
        // Field to hold the authentication service class
        private readonly IAuthentication _authenticationService;

        // Constructor
        public AuthenticationController(IAuthentication authenticationService)
        {
            _authenticationService = authenticationService;
        }


        // Controller Methods
        public async Task<string> HashPassword(string username, string plainText)
        {
            return await _authenticationService.UpdatePassword(username, plainText);
        }

        public async Task<string> GetDefaultPassword()
        {
            return await _authenticationService.GetDefaultPassword();
        }

        public async Task<string> GetDefaultPassword(string username)
        {
            return await _authenticationService.GetDefaultPassword(username);
        }

        public async Task<string> DecodePassword(string username)
        {
            return await _authenticationService.DecryptPassword(username);
        }

        public async Task<bool> GenerateKeyAndIV(string username)
        {
            return await _authenticationService.GenerateKeyAndIV(username);
        }
    }
}
