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
                Console.WriteLine("������������ {0} �������������", currentUser.Login);
                return true;
            }
            else
            {
                // ����� ���������� � ������� ��������� ������
                Console.WriteLine("������� ����� � ������� ��������� �������");
                return false;
            }

        }

        public static bool Registration(string UserName, string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.UserLoginCheck(UserLogin))
            {
                Console.WriteLine("����������� ������ ������������ {0}", UserName);
                DatabaseUsersManager.CreateNewUser(UserName, UserLogin, UserPassword);
                return true;
            }
            else
            {
                Console.WriteLine("������� ����������� � ������� �������");
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
                Console.WriteLine("��� ������ 0; ������������ �� � currentUsers")
                return (0)
            }
            //�������� �� ���������� ������������ � currentUsers

            for(int i = 0; i <= WeekBooking.Length; i++)
            {
                if (Actuall.IsVip == 0 && Actuall.IsAdmin == 0)
                {
                    if (WeekBooking[i].UserId == Actuall.Id)
                    {
                        Console.WriteLine("��� ������ 3;������������ ��������� ������������ ����� ������� (1)");
                        return (3)
                    }
                }
                if (Actuall.IsVip == 1 && Actuall.IsAdmin == 0 )
                {
                    int k == 0;
                    if (WeekBooking[i].UserId == Actuall.Id) { k += 1; }
                    if (k >= 3)
                    {
                        Console.WriteLine("��� ������ 4;������������ ��������� ������������ ����� ������� (3)");
                        return (4)
                    }
                } 
            }

            // �������� �� ���-�� ������� �� ������ ���������

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
                        Console.WriteLine("��� ������ 2; ����� ��� ������")
                        return (2);
                    }
                }
            }

            // �������� �� ��������� ����� ���������

            Console.WriteLine("��� ������ 1; ������������ ������� ������������ �����������");
            return (1);


        }
    }

}