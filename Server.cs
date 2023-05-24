using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolodosServer
{
    public class Server
    {
        List<(User, DateTime)> currentUsers = new List<(User, DateTime)>();
        bool LogIn(string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.LogInProfile(UserLogin, UserPassword))
            {
                currentUsers.Add((DatabaseUsersManager.UserLoginCheck(UserLogin), DateTime.UtcNow));
                Console.WriteLine("Вы успешно авторизовались");
                return true;
            }
            else
            {
                // вывод оповещения о неверно введенных данных
                Console.WriteLine("Произошла ошибка, проверьте корректность введеных данных");
                return false;
            }

        }

        bool Registration(string UserName,string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.UserLoginCheck(UserLogin) == null)
            {
                User user = new User(UserName, UserLogin, UserPassword);
                Console.WriteLine("Вы успешно зарегистрировались");
                return true;
            }
            else
            {
                Console.WriteLine("Пользователь с таким login уже существует, попробуйте другой");
                return false;
            }
            
        }

    }

}