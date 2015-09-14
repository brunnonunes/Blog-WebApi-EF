using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Blog.Api.Utility
{
    /// <summary>
    /// Classe para geração de criptografia
    /// </summary>
    public class Cryptography
    {
        //MD5 (hash) -> Message Digest 5 (128bits)
        public static string GetMD5Hash(string Param)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(Param));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}