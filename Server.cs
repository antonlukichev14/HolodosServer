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
            User currentUser = DatabaseUsersManager.UserEnter(UserLogin, UserPassword);

            if (currentUser != null)
            {
                currentUsers.Add((currentUser, DateTime.UtcNow));
                Console.WriteLine("Пользователь {0} авторизовался", currentUser.Login);
                return true;
            }
            else
            {
                // вывод оповещения о неверно введенных данных
                Console.WriteLine("Попытка входа с неверно введёнными данными");
                return false;
            }

        }

        bool Registration(string UserName,string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.UserLoginCheck(UserLogin))
            {
                Console.WriteLine("Регистрация нового пользователя {0}", UserName);
                DatabaseUsersManager.CreateNewUser(UserName, UserLogin, UserPassword);
                return true;
            }
            else
            {
                Console.WriteLine("Попытка регистрации с занятым логином");
                return false;
            }
            
        }

        void FreezerBooking(string UserLogin, Booking UserBooking)
        {

        }

    }

}