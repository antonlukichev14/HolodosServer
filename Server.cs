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

        public static void FreezerBooking(string UserLogin, Booking UserBooking)
        {

        }
    }

}