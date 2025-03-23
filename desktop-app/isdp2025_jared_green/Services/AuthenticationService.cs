using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using idsp2025_jared_green.Entities;
using Microsoft.EntityFrameworkCore;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Security.Cryptography;

namespace idsp2025_jared_green.Services
{
    internal class AuthenticationService : IAuthentication
    {
        // Declare the static logger.
        private static readonly NLog.Logger AuthenticationLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private readonly BullseyeContext _bullseyeContext;
        private readonly IEncryption _encryptionService;
        private readonly IEmployees _employeeService;

        public AuthenticationService(IEncryption encryptionService, IEmployees employeeService, BullseyeContext context) 
        { 
            _encryptionService = encryptionService;
            _employeeService = employeeService;
            _bullseyeContext = context;
        }

        public async Task<bool> GenerateKeyAndIV(string username)
        {
            try
            {
                var keyVaultUri = configuration["KeyVault:Uri"];

                // SecretClient is a class used to interact with Azure Key Vault secrets. It provides methods for storing,
                // retrieving and managing secrets.
                // DefaultAzureCredential is a class that provides a mechanism for authenticating to Asure Services.
                var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

                byte[] key = GenerateRandomCryptographicKey(256);
                byte[] IV = GenerateRandomCryptographicKey(128);

                string keyString = Convert.ToBase64String(key);
                string IVString = Convert.ToBase64String(IV);
                string secretValueString = $"{keyString}:{IVString}";

                // Generate Secret Value Based on the Username Logged In.
                var secretName = username;

                await client.SetSecretAsync(secretName, secretValueString);

                // MessageBox.Show($"Secret '{secretName}' stored successfully.");
                return true;
            }
            catch (Exception ex)
            {
                // Need to add exception logging...
                return false;
            }
        }

        public static byte[] GenerateRandomCryptographicKey(int keySizeInBits)
        {
            // Convert from bits to bytes.
            byte[] key = new byte[keySizeInBits / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }


        public async Task<string> UpdatePassword(string username, string password)
        {
            try
            {
                    var employee = await (from emp in _bullseyeContext.Employees
                                   where emp.Username == username
                                   select emp).FirstOrDefaultAsync();

                    // In order to create a secure password, I must do three things:
                    // 1. Generate a security key,
                    // 2. Store a security key, 
                    // 3. Hash the password

                    var keyAndIv = await _encryptionService.RetrieveKeyAndIV(username);

                    if (keyAndIv != null)
                    {
                        byte[] k = keyAndIv.Value.Item1;
                        byte[] Iv = keyAndIv.Value.Item2;
                        byte[] encryptedPass = _encryptionService.HashPassword(password, k, Iv);

                        employee.Password = Convert.ToBase64String(encryptedPass);

                        // await _bullseyeContext.SaveChangesAsync();
                        // return true;
                        return employee.Password;

                    }
                    else
                    {
                        throw new ArgumentException();
                    }
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return "An error occurred updating the password.";
            }
        }

        public async Task<string>GetDefaultPassword()
        {
            try
            {

                // Retrieve the key for the default password
                var keyAndIv = await _encryptionService.RetrieveKeyAndIV("DefaultPassword");

                if (keyAndIv != null)
                {
                    byte[] k = keyAndIv.Value.Item1;
                    byte[] Iv = keyAndIv.Value.Item2;

                    byte[] encryptedPasswordBytes = _encryptionService.HashPassword("P@$$w0rd-", k, Iv);

                    string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                    return encryptedPassword;
                }
                return "";
             
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<string> GetDefaultPassword(string username)
        {
            try
            {

                // Retrieve the key for the default password
                var keyAndIv = await _encryptionService.RetrieveKeyAndIV(username);

                if (keyAndIv != null)
                {
                    byte[] k = keyAndIv.Value.Item1;
                    byte[] Iv = keyAndIv.Value.Item2;

                    byte[] encryptedPasswordBytes = _encryptionService.HashPassword("P@ssw0rd-", k, Iv);

                    string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                    // ✅ Copy password to clipboard
                    //Clipboard.SetText(encryptedPassword);

                    // ✅ Show password in a message box with a copy confirmation
                    // MessageBox.Show($"Default password copied to clipboard for {username}:\n\n{encryptedPassword}", "Password Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return encryptedPassword;
                }
                return "";

            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<bool>ResetPasswordToDefault(string username) 
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var employee = (from emp in context.Employees
                                    where emp.Username == username
                                    select emp).First();

                    // Retrieve the key for the default password
                    var keyAndIv = await _encryptionService.RetrieveKeyAndIV(username);

                    if (keyAndIv != null)
                    {
                        byte[] k = keyAndIv.Value.Item1;
                        byte[] Iv = keyAndIv.Value.Item2;

                        byte[] encryptedPassword = _encryptionService.HashPassword("P@$$w0rd-", k, Iv);

                        employee.Password = Convert.ToBase64String(encryptedPassword);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            // Add any other type of exceptions that I explicitly want to catch.
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AttemptLogin(string username, string password)
        {
            // 1. See if there is a user that matches the provided username.
            Employee? employee = await _employeeService.GetEmployeeByUsername(username);

            // 2. If there is a match, check if the password matches.
            if (employee != null)
            {
                var keyAndIv = await _encryptionService.RetrieveKeyAndIV(username);
                if (keyAndIv != null)
                {
                    byte[] k = keyAndIv.Value.Item1;
                    byte[] Iv = keyAndIv.Value.Item2;
                    // MessageBox.Show("Key: " + Convert.ToBase64String(k));
                    // MessageBox.Show("IV: " + Convert.ToBase64String(Iv));
                    byte[] encryptedPass = _encryptionService.HashPassword(password, k, Iv);
                    string stringEncryptedPass = Convert.ToBase64String(encryptedPass);
                    if (encryptedPass != null && stringEncryptedPass == employee.Password)
                    //if (encryptedPass != null && encryptedPass == Encoding.UTF8.GetBytes(employee.Password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<string> DecryptPassword(string username)
        {
            try
            {
                // Retrieve the key and IV from Azure Key Vault
                var keyAndIv = await _encryptionService.RetrieveKeyAndIV(username);

                if (keyAndIv != null)
                {
                    byte[] key = keyAndIv.Value.Item1;
                    byte[] iv = keyAndIv.Value.Item2;

                    // Retrieve the encrypted password from the database
                    var employee = await _employeeService.GetEmployeeByUsername(username);
                    if (employee == null || string.IsNullOrEmpty(employee.Password))
                        return "User not found or no password set.";

                    // Convert the stored Base64 string back to byte array
                    byte[] encryptedPasswordBytes = Convert.FromBase64String(employee.Password);

                    // Decrypt using AES
                    string decryptedPassword = DecryptWithAES(encryptedPasswordBytes, key, iv);

                    return decryptedPassword;
                }

                return "Key and IV not found.";
            }
            catch (Exception ex)
            {
                return $"Error decrypting password: {ex.Message}";
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
