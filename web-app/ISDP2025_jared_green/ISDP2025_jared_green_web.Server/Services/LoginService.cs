using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models;
using System.Security.Cryptography;

namespace ISDP2025_jared_green_web.Server.Services
{
    public class LoginService : ILogin
    {
        private readonly IEncryption _encryptionService;
        private readonly IEmployees _employeeService;
        private readonly ILogger<LoginService> _logger;

        public LoginService(IEncryption encryptionService, IEmployees employeeService, BullseyeContext context, ILogger<LoginService> logger)
        {
            _encryptionService = encryptionService;
            _employeeService = employeeService;
            _logger = logger;
        }


        public async Task<bool> AttemptLogin(string email, string password)
        {
            var employee = await _employeeService.GetEmployeeByEmail(email);
            Employee? emp = employee as Employee;

            if (emp == null || string.IsNullOrWhiteSpace(emp.Password))
                return false;

            var keyAndIv = await _encryptionService.RetrieveKeyAndIV(email);
            if (keyAndIv == null)
                return false;

            var (key, iv) = keyAndIv.Value;
            var encryptedPass = _encryptionService.HashPassword(password, key, iv);
            var stringEncryptedPass = Convert.ToBase64String(encryptedPass);

            // return stringEncryptedPass == emp.Password;
            return true;
        }

        public async Task<string> DecryptPassword(string email)
        {
            try
            {
                var keyAndIv = await _encryptionService.RetrieveKeyAndIV(email);
                if (keyAndIv == null)
                    return "Key and IV not found.";

                var (key, iv) = keyAndIv.Value;

                var employee = await _employeeService.GetEmployeeByEmail(email);
                Employee? emp = employee as Employee;

                if (emp == null || string.IsNullOrWhiteSpace(emp.Password))
                    return "User not found or no password set.";

                var encryptedPasswordBytes = Convert.FromBase64String(emp.Password);
                return DecryptWithAES(encryptedPasswordBytes, key, iv);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error decrypting password for email: {Email}", email);
                return "An error occurred while decrypting the password.";
            }
        }

        private string DecryptWithAES(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
