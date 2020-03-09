using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Reservation
{
    public class MD5
    {
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static int add(int x,int y)
        {
            return x + y;
        }
    }
}
