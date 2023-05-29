using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = DatabaseUsersManager.UserEnter("Login", "Password");
            Console.WriteLine(user.Name);


        }
    }
}
