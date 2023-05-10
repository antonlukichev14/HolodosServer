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
            static string filePath = Path.Combine(Environment.CurrentDirectory, "UserData.txt");

            public static string[] GetString()
            {
                return File.ReadAllLines(filePath); //Если здесь возникла ошибка, значит надо перенести файл с базой данных (UserData.txt) в (папка с кодом)\bin\Debug\net5.0\
            }

            public static void Add(User user)
            {
                string writeString = $"{user.Id} {user.Name} {user.Login} {user.Password} {user.IsVip} {user.IsAdmin}";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(writeString);
                }
            }
        }
    }
}
