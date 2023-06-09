using System;
using System.IO;

namespace HolodosServer
{
    namespace Database
    {
        //Низкоуровневый класс для работы с базой данных записи
        //Тут всё по работе с файлами
        //Скрыт под namespace, поскольку большинству не нужен
        static class DatabaseBooking
        {
            static uint currentID = 0;
            static string filePath = Path.Combine(Environment.CurrentDirectory, "data/BookingData.txt");

            public static string[] GetString()
            {
                if (File.Exists(filePath)) return File.ReadAllLines(filePath);
                return null;
            }

            public static void Add(uint _CityId, uint _PlaceId, string _UserId, byte _FType, DateTime _Date, int _Hours)
            {
                uint _BookingId = currentID;
                currentID++;
                string writeString = $"\n{_BookingId} {_CityId} {_PlaceId} {_UserId} {_FType} {_Date.ToString()} {_Hours}";

                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(writeString);
                }
            }

            public static void DatabaseCheck()
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                    Console.WriteLine("База данных бронирования создана");
                    return;
                }
                Console.WriteLine("База данных бронирования найдена");

               currentID = (uint)File.ReadAllLines(filePath).Length;
            }
        }
    }
}

