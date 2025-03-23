using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Interfaces.Services
{
    internal interface IEncryption
    {
        Task<bool> GenerateKeyAndIV(string key);

        Task<(byte[], byte[])?> RetrieveKeyAndIV(string username);

        byte[] HashPassword(string plainText, byte[] key, byte[] IV);

        string VerifyPassword(byte[] hash, byte[] key, byte[] IV);
    }
}
