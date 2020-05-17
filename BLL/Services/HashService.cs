using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public static class HashService
    {
        public static string GetHashString (string inputString)
        {
            string salt = "A123b456Z789y0@";
            byte[] buffer = Encoding.Unicode.GetBytes(inputString + salt);
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(buffer);

            return Convert.ToBase64String(hash);
        }
    }
}
