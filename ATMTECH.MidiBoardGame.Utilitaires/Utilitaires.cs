using System;
using System.Security.Cryptography;
using System.Text;

namespace ATMTECH.MidiBoardGame.Utilitaires
{
    public static class Utilitaires
    {
        public static DateTime Aujourdhui()
        {
            return Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }

        public static string HashEmailForGravatar(string email)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string ObtenirImageGravatar(string email)
        {
            string hash = HashEmailForGravatar(email);
            return string.Format("http://www.gravatar.com/avatar/{0}", hash);
        }
    }
}