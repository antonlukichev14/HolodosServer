using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            static string filePath = Path.Combine(Environment.CurrentDirectory, "data/UserData.txt");

            public static string[] GetString()
            {
                if(File.Exists(filePath)) return File.ReadAllLines(filePath);
                return null;
            }

            public static void Add(string name, string login, string password)
            {
                string writeString = $"{name} {login} {password} {0} {0}";

                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(writeString);
                }
            }

            public static void DatabaseCheck()
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                    Console.WriteLine("База данных пользователей создана");
                    return;
                }
                Console.WriteLine("База данных пользователей найдена");
            }
        }
    }
}
