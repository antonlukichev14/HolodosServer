using System;
using System.Collections.Generic;

namespace HolodosServer
{
    public class Server
    {
        List<(User, DateTime)> currentUsers = new List<(User, DateTime)>();
        bool LogIn(string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.UserEnter(UserLogin, UserPassword))
            {
                currentUsers.Add((DatabaseUsersManager.UserLoginCheck(UserLogin), DateTime.UtcNow));
                Console.WriteLine("�� ������� ��������������");
                return true;
            }
            else
            {
                // ����� ���������� � ������� ��������� ������
                Console.WriteLine("��������� ������, ��������� ������������ �������� ������");
                return false;
            }

        }

        bool Registration(string UserName, string UserLogin, string UserPassword)
        {
            if (DatabaseUsersManager.UserLoginCheck(UserLogin) == null)
            {
                User user = new User(UserName, UserLogin, UserPassword);
                Console.WriteLine("�� ������� ������������������");
                LogIn(UserLogin, UserPassword);
                return true;
            }
            else
            {
                Console.WriteLine("������������ � ����� login ��� ����������, ���������� ������");
                return false;
            }

        }
        void FreezerBooking(string UserLogin, Booking UserBooking)
        {

        }

    }

}