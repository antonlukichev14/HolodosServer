using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolodosServer
{
    public static class Server
    {
        static List<(User, DateTime)> currentUsers = new List<(User, DateTime)>();

        public static bool LogIn(string UserLogin, string UserPassword)
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

        public static bool Registration(string UserName, string UserLogin, string UserPassword)
        {
            if (!DatabaseUsersManager.UserLoginCheck(UserLogin))
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

        public static byte FreezerBooking(string UserLogin, Booking UserBooking)
        {
            Booking[] DayBooking =  DatabaseBookingManager.DayRec(UserBooking.CityId, UserBooking.PlaceId, UserBooking.Date);
            Booking[] WeekBooking =  DatabaseBookingManager.WeekRec(UserBooking.Date);
            User Actuall = DatabaseUsersManager.GetUser(UserLogin);

            bool a = false;
            foreach((User, DateTime) _user in currentUsers)
            {
                if (_user.Item1.Login == UserLogin) a = true;
            }
            if(!a)
            {
                Console.WriteLine("Код ошибки 0; Пользователя нет в списке currentUsers");
                return 0;
            }
            //проверка на нахождениу пользователя в currentUsers

            for(int i = 0; i < WeekBooking.Length; i++)
            {
                if (!Actuall.IsVip && !Actuall.IsAdmin)
                {
                    if (WeekBooking[i].UserId == Actuall.Login)
                    {
                        Console.WriteLine("Код ошибки 3; Пользователь превышает максимальный лимит записей (1)");
                        return 3;
                    }
                }
                if (Actuall.IsVip && !Actuall.IsAdmin)
                {
                    int k = 0;
                    if (WeekBooking[i].UserId == Actuall.Login) { k += 1; }
                    if (k >= 3)
                    {
                        Console.WriteLine("Код ошибки 4; Пользователь превышает максимальный лимит записей (3)");
                        return 4;
                    }
                } 
            }

            // проверка на кол-во записей за неделю завершена

            List<int> OccupiedTime = new List<int>();

            for(int i = 0; i < DayBooking.Length; i++)
            {
                for(int j = 0; j < DayBooking[i].Hours; j++)
                {
                    int Hour = DayBooking[i].Date.TimeOfDay.Hours + j;
                    OccupiedTime.Add(Hour);
                }
            }

            for(int i = 0; i < UserBooking.Hours; i++)
            {
                int UserHour = UserBooking.Date.TimeOfDay.Hours + i;
                for(int j = 0; j < OccupiedTime.Count; j++)
                {
                    if(UserHour == OccupiedTime[j])
                    {
                        Console.WriteLine("Код ошибки 2; Время уже занято");
                        return 2;
                    }
                }
            }

            // проверка на незанятое время завершено

            DatabaseBookingManager.BookingInBase(UserBooking);
            Console.WriteLine("Код исхода 1; Пользователь успешно забронировал холодильник");
            return 1;


        }
    }

}