using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Common
{
    public class MD5Encryption
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="express">明文</param>
        /// <returns>密文</returns>
        public static string Encryption(string express)
        {
            var ciphertext = "";
            byte[] result = Encoding.Default.GetBytes(express);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            ciphertext = BitConverter.ToString(output).Replace("-", "");
            return ciphertext;
        }
    }
}
