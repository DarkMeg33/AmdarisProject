using System.Security.Cryptography;
using System.Text;

namespace AmdarisProject.Core.Infrastructure
{
    internal static class Cryptography
    {
        public static string HashString(string str)
        {
            using var hmac = new HMACSHA512();
            var byteHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(str));

            string hash = "";

            foreach (byte b in byteHash)
                hash += $"{b:x2}";

            return hash;
        }
    }
}
