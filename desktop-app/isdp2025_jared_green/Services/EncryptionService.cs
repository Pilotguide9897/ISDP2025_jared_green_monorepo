using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace idsp2025_jared_green.Services
{
    internal class EncryptionService : IEncryption
    {
        // Declare the static logger.
        private static readonly NLog.Logger EncryptionLogger = NLog.LogManager.GetCurrentClassLogger();

        // Set up configuration manager to be able to use appsettings.json
        private IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static byte[] GenerateRandomCryptographicKey(int keySizeInBits)
        {
            // Convert from bits to bytes.
            byte[] key = new byte[keySizeInBits/8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        // Returns either true or false based on whether the storage was successful.
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
                // Need to add exception logging..
                MessageBox.Show("There has been a problem with Azure Key Services.", "Azure Error");
                return false;
            }
        }

        public async Task<(byte[], byte[])?> RetrieveKeyAndIV(string username)
        {
            try
            {
                var keyVaultUri = configuration["KeyVault:Uri"];
                var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
                KeyVaultSecret secret = await client.GetSecretAsync(username);
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
                EncryptionLogger.Error(ex, "An error occurred accessing the password");
                return null;
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
