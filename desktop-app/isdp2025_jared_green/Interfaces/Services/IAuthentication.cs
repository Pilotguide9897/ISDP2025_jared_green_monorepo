using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace idsp2025_jared_green.Interfaces.Services
{
    public interface IAuthentication
    {
        // bool ValidatePassword(string password);

        Task<string> UpdatePassword(string username, string password);

        Task<bool> AttemptLogin(string username, string password);

        public Task<string> GetDefaultPassword();

        public Task<string> GetDefaultPassword(string username);

        public Task<bool> ResetPasswordToDefault(string username);

        public Task<bool> GenerateKeyAndIV(string username);

        public Task<string> DecryptPassword(string username);

    }
}
