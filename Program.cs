using System;
using BCrypt.Net;

namespace hashing_passwords_with_salt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать! Создайте учетную запись.");
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine()!;
            // Генерируем соль
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            // Хешируем пароль с использованием соли
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password + salt);
            Console.WriteLine("Учетная запись успешно создана.");
            // Эмулируем процесс входа в систему
            Console.WriteLine("\nВход в систему:");
            Console.Write("Введите имя пользователя: ");
            string loginUsername = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            string loginPassword = Console.ReadLine()!;
            // Загрузка соли из базы данных или другого хранилища для данного пользователя
            string loginSalt = salt; // В реальности, нужно загружать соль из базы данных
            // Проверка введенных данных
            if (loginUsername == username && BCrypt.Net.BCrypt.Verify(loginPassword + loginSalt, hashedPassword))
                Console.WriteLine("Вход в систему успешно выполнен.");
            else
                Console.WriteLine("Неверное имя пользователя или пароль.");
        }
    }
}