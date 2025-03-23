using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    internal interface IJsonWebToken
    {
        public string GenerateToken(string username, List<Posn> roles);

        public string GenerateToken(string username, List<Posn> roles, string location);

        public string GenerateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        public ClaimsPrincipal? ValidateToken(string token);

        public string RefreshToken(IEnumerable<Claim> claims);

        public List<string> GetRolesFromToken(string token);

        public List<string> ExtractUserInfoFromToken(string token);

    }
}
