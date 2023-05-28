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
        public static bool LogInProfile(string login, string password)
        {
            return true;
        }

        public static bool CreateNewUser(User user)
        {
            return true;
        }
        public static User UserLoginCheck(string login) // тут должна быть функция которая сопоставляет логин и/или пароль с экземпляром User
        {
            User user = null;
            return user;
        }

        public static User GetUser(string login) //функция ищет пользователя с указанным логином и возвращает экземпляр User с данными из базы данных
        {
            return new User();
        }
    }
}
