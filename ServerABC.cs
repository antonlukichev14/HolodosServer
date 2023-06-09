using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HolodosServer
{
    static class ServerABC
    {
        public static void server()
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            // IPEndPoint - конечная точка содержащая IP и порт.

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // AddressFamily.InterNetwork - задает схему адресации.
            // SocketType.Stream - Указывает тип сокета, являющегося экземпляром класса Socket, поддерживает надежные двусторонние байтовые потоки в режиме с установлением подключения.
            // ProtocolType - протокол сети интернет, который позволяет двум хостам создать соединение и обмениваться потоками данных.

            tcpSocket.Bind(tcpEndPoint);
            // Bind - связывает локальный адрес с сокетом.

            tcpSocket.Listen(5);
            // Listen(5) - Устанавливает объект Socket в состояние прослушивания.

            // Далее процес прослушивания.

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[1024];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);

                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    listener.Send(Encoding.UTF8.GetBytes(ent(data.ToString())));

                } while (listener.Available > 0);

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }

        public static string ent(string abc)
        {
            string[] a = abc.Split(' ');

            switch (a[0])
            {
                //LogIn
                case "A":
                    bool n = Server.LogIn(a[1], a[2]);
                    if (n) return "a 1";
                    return "a 0";
                //Reg
                case "B":
                    bool m = Server.Registration(a[1], a[2], a[3]);
                    if (m) return "b 1";
                    return "b 0";
                //Booking
                case "C":
                    Booking newB = new Booking(0, uint.Parse(a[2]), uint.Parse(a[3]), a[1], byte.Parse(a[4]), new DateTime(int.Parse(a[5]), int.Parse(a[6]), int.Parse(a[7]), int.Parse(a[8]), 0, 0), int.Parse(a[9]));
                    byte v = Server.FreezerBooking(a[1], newB);
                    return $"c {v.ToString()}";
                //City
                case "D":
                    return $"d {DatabaseCity.GetCities()}";
                //Place
                case "F":
                    return $"f___{DatabaseCity.GetPlaces(int.Parse(a[1]))}";
            }

            return null;
        }
    }
}
