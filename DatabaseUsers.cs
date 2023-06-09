using System;
using System.IO;

namespace HolodosServer
{
    namespace Database
    {
        //Низкоуровневый класс для работы с базой данных пользователей
        //Тут всё по работе с файлами
        //Скрыт под namespace, поскольку большинству не нужен
        //P.S. бывший Database.cs
        static class DatabaseUsers
        {
            static string directoryPath = Path.Combine(Environment.CurrentDirectory, "data");
            static string filePath = Path.Combine(Environment.CurrentDirectory, "data/UserData.txt");

            public static string[] GetString()
            {
                if (File.Exists(filePath)) return File.ReadAllLines(filePath);
                return null;
            }

            public static void Add(string name, string login, string password)
            {
                string writeString = $"{name} {login} {password} {0} {0}\n";

                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(directoryPath);
                    File.Create(filePath);
                }

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(writeString);
                }
            }

            public static void DatabaseCheck()
            {
                if (!File.Exists(filePath))
                {
                    Directory.CreateDirectory(directoryPath);
                    File.Create(filePath);
                    Console.WriteLine("База данных пользователей создана");
                    return;
                }
                Console.WriteLine("База данных пользователей найдена");
            }
        }
    }
}
