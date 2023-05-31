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

        byte FreezerBooking(string UserLogin, Booking UserBooking)
        {
            Booking[] DayBooking = new Booking[]; DayBooking = DatabaseBookingManager.DayRec(UserBooking.CityId, UserBooking.PlaceId, UserBooking.Date);
            Booking[] WeekBooking = new Booking[]; WeekBooking = DatabaseBookingManager.WeekRec();
            User Actuall = new User(); Actuall = DatabaseUsersManager.GetUser(UserLogin);

            if (currentUsers.Exists(x => x.Item1 == Actuall) == false)
            {
                Console.WriteLine("Код ошибки 0; Пользователь не в currentUsers")
                return (0)
            }
            //проверка на нахождениу пользователя в currentUsers

            for(int i = 0; i <= WeekBooking.Length; i++)
            {
                if (Actuall.IsVip == 0 && Actuall.IsAdmin == 0)
                {
                    if (WeekBooking[i].UserId == Actuall.Id)
                    {
                        Console.WriteLine("Код ошибки 3;Пользователь превышает максимальный лимит записей (1)");
                        return (3)
                    }
                }
                if (Actuall.IsVip == 1 && Actuall.IsAdmin == 0 )
                {
                    int k == 0;
                    if (WeekBooking[i].UserId == Actuall.Id) { k += 1; }
                    if (k >= 3)
                    {
                        Console.WriteLine("Код ошибки 4;Пользователь превышает максимальный лимит записей (3)");
                        return (4)
                    }
                } 
            }

            // проверка на кол-во записей за неделю завершена

            List<int> OccupiedTime = new List<int>

            for(int i = 0; i <= DayBooking.Length; i++)
            {
                for(int j = 0; j <= DayBooking[i].Hours; j++)
                {
                    int Hour = DayBooking[i].Time + j;
                    OccupiedTime.Add(Hour);
                }
            }

            for(int i = 0; i <= UserBooking.Hours; i++)
            {
                int UserHour = UserBooking.Time + i;
                for(int j = 0; j <= OccupiedTime.Count; j++)
                {
                    if(UserHour == OccupiedTime[j])
                    {
                        Console.WriteLine("Код ошибки 2; Время уже занято")
                        return (2);
                    }
                }
            }

            // проверка на незанятое время завершено

            Console.WriteLine("Код исхода 1; Пользователь успешно забронировал холодильник");
            return (1);


        }
    }

}