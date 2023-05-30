using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = DatabaseUsersManager.UserEnter("victor3", "rapo3");
            Console.WriteLine(user.Name);


        }
    }
}
