using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ISDP2025_jared_green_web.Server.Services
{
    internal class EncryptionService : IEncryption
    {
        // Declare the static logger.
        private readonly ILogger<CustomerOrdersService> _logger;

        // Set up configuration manager to be able to use appsettings.json
        private IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public EncryptionService(ILogger<CustomerOrdersService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(byte[], byte[])?> RetrieveKeyAndIV(string username)
        {
            try
            {
                var keyVaultUri = configuration["KeyVault:Uri"];
                var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

                // Not secure, but fine for development.
                KeyVaultSecret secret = await client.GetSecretAsync("admin");
                string retrievedValue = secret.Value;

                //string secret = "dQMljl7CrMyEztheH3q3jzQpcK0+m76CIoaOpWWDyf4=:CLhGjVWmR7gxHBrnmLD5XQ==";

                // Split the secret at the colon
                string[] parts = retrievedValue.Split(':');
                if (parts.Length != 2)
                {
                    throw new InvalidOperationException("The secret format is incorrect.");
                }

                byte[] key = Convert.FromBase64String(parts[0]);
                byte[] iv = Convert.FromBase64String(parts[1]);

                return (key, iv);
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred accessing the password");
                throw;
            }
        }

        public byte[] HashPassword(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string VerifyPassword(byte[] cipherText, byte[] Key, byte[] IV)
        {

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a descriptor to perform the stream transform.
                ICryptoTransform descriptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, descriptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
