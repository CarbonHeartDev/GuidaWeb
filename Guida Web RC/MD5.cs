using System;
using System.Security.Cryptography;
using System.Text;


namespace Guida_Web_RC
{
    public static class Hashing
    {
        /*La seguente funzione resituisce in forma di stringa un hash della stringa data in input.*/
        public static String ComputeHash(String input)
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
    }
}