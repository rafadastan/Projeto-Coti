using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoAPI01.CrossCutting
{
    public class Criptografia
    {
        //método para receber um valor e retorna-lo em MD5
        public static string GetMD5(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("x2"); //x2 -> hexadecimal
            }

            return result;
        }
    }
}
