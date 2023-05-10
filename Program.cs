using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.DatabaseUsers.DatabaseCheck();

            Console.WriteLine(DatabaseUsersManager.CreateNewUser("Ban", "Darkcolm", "gachi"));
        }
    }
}
