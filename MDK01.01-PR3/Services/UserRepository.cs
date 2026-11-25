using System.Collections.Generic;
using System.Linq;
using MDK01._01_PR3.Models;

namespace MDK01._01_PR3.Services
{
    /// <summary>
    /// Тестовое хранилище пользователей (вместо базы данных).
    /// Пароли хранятся в виде хэша.
    /// Тестовые учётные записи: client / client123, admin / admin123
    /// </summary>
    public static class UserRepository
    {
        private static readonly List<User> users = new List<User>
        {
            new User { Login = "client", PasswordHash = Hash.HashPassword("client123"), Role = "Клиент" },
            new User { Login = "admin",  PasswordHash = Hash.HashPassword("admin123"),  Role = "Администратор" }
        };

        public static User Find(string login, string password)
        {
            string hash = Hash.HashPassword(password);
            return users.FirstOrDefault(u => u.Login == login && u.PasswordHash == hash);
        }
    }
}
