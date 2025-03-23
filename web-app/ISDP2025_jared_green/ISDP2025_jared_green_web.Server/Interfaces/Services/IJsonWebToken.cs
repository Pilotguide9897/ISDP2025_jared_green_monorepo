using ISDP2025_jared_green_web.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface IJsonWebToken
    {
        public string GenerateToken(string username, List<string> roles);

    }
}
