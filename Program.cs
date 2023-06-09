using System;
using HolodosServer.Database;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DatabaseUsers.DatabaseCheck();
            DatabaseBooking.DatabaseCheck();

            Console.WriteLine("Start server? 1/0");
            ConsoleKey a = Console.ReadKey().Key;
            Console.WriteLine("");
            if(a == ConsoleKey.D1)
            {
                ServerABC.server();
            }
            if(a == ConsoleKey.D0)
            {
                ManualInput();
            }
        }

        static void ManualInput()
        {
            Console.WriteLine("Manual input mode is activated!");

            while (true)
            {
                string a = Console.ReadLine();
                Console.WriteLine($"Server return: {ServerABC.ent(a)}");
            }
        }
    }
}
