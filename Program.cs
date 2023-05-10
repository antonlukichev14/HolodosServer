using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(3, "Ban", "Darkcolm", "gachi", true, true);
            Console.WriteLine(DatabaseUsersManager.CreateNewUser(user));
        }
    }
}
