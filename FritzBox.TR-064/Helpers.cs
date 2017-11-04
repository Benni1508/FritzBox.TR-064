using System;
using System.Security.Cryptography;
using System.Text;

namespace FritzBox.Tr064
{
    public static class Helpers
    {
        public static string Md5(string str)
        {
            var enco = new UTF8Encoding().GetBytes(str);
            var md5 = MD5.Create().ComputeHash(enco);
            return BitConverter.ToString(md5).Replace("-", "").ToLower();
        }
    }
}