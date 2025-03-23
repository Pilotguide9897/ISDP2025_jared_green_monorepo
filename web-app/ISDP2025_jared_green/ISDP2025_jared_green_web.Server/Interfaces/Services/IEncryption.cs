using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Interfaces.Services
{
    public interface IEncryption
    {

        Task<(byte[], byte[])?> RetrieveKeyAndIV(string username);

        byte[] HashPassword(string plainText, byte[] key, byte[] IV);

        string VerifyPassword(byte[] hash, byte[] key, byte[] IV);
    }
}
