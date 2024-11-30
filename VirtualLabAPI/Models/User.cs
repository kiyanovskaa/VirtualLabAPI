using System.Runtime.CompilerServices;

namespace VirtualLabAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Унікальний ідентифікатор
        public string Username { get; set; } // Ім'я користувача (унікальне)
        public string Email { get; set; } // Електронна пошта (унікальна)
        public string PasswordHash { get; set; } // Хеш пароля
        public string Role { get; set; } // Роль (наприклад, "Admin", "User")
        public string FirstName { get; set; } // Ім'я
        public string LastName { get; set; } // Прізвище

    }
}
