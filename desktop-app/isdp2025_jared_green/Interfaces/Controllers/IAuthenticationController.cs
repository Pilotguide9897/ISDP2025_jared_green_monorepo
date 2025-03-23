using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IAuthenticationController
    {
        public Task<string> HashPassword(string username, string plainText);

        public Task<string> GetDefaultPassword();

        public Task<string> GetDefaultPassword(string username);

        public Task<string> DecodePassword(string encodedPassword);

        public Task<bool> GenerateKeyAndIV(string username);
    }
}
