using System;
using System.Security.Cryptography;
using System.Text;

namespace Dungeons_and_Dragons
{
    public class Md5Hash
    {
        static MD5 md5Hash;

        public Md5Hash ()
        {
            md5Hash = MD5.Create();
        }

        public string GetHash (string input)
        {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
        }

        public bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetHash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

