using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных пользователей
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    //P.S. бывший Login.cs
    static class DatabaseUsersManager
    {
        public static User UserEnter(string login, string password)
        {
            return new User();
        }

        public static bool CreateNewUser(string UserName, string UserLogin, string UserPassword)
        {
            return true;
        }

        public static bool UserLoginCheck(string login) // тут функция которая сопоставляет логин с базой данных
        {
            return true;
        }

        public static User GetUser(string login) //функция ищет пользователя с указанным логином и возвращает экземпляр User с данными из базы данных
        {
            return new User();
        }
    }
}
