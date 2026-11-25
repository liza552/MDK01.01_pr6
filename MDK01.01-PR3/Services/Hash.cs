using System;
using System.Security.Cryptography;
using System.Text;

namespace MDK01._01_PR3.Services
{
    public class Hash
    {
        /// <summary>
        /// Хэширует пароль алгоритмом SHA256, возвращает строку в шестнадцатеричном формате.
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(sourceBytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }
}
