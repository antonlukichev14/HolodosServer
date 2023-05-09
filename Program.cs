using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Login login = new Login();
            User user = new User(3, "Ban", "Darkcolm", "gachi", true, true);
            Console.WriteLine(login.CreateNewUser(user));







        }
    }
}
