using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolodosServer.Database;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных пользователей
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    //P.S. бывший Login.cs
    static class DatabaseUsersManager
    {
        public static bool LogInProfile(string login, string password)
        {
            string[] lines = DatabaseUsers.GetString();
            bool isLogIn = false;
            for (int i = 0; i < lines.Length; i++)
            {

                string[] tempAr = lines[i].Split(' ');
                if (tempAr[2] == login)
                {
                    if (tempAr[3] == password)
                    {
                        isLogIn = true;
                    }
                }
            }
            return isLogIn;
        }

        public static bool CreateNewUser(User user)
        {
            if (!LogInProfile(user.Login, user.Password))
            {
                DatabaseUsers.Add(user);
                return true;
            }
            return false;
        }
    }
}
