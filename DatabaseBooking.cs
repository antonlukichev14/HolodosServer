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
            static string filePath = Path.Combine(Environment.CurrentDirectory, "data/BookingData.txt");

            public static string[] GetString()
            {
                if (File.Exists(filePath)) return File.ReadAllLines(filePath);
                return null;
            }

            public static void Add(uint _BookingId, uint _CityId, uint _PlaceId, uint _UserId, byte _FType, DateTime _DateStart, DateTime _DateFinish)
            {
                string writeString = $"\n{_BookingId} {_CityId} {_PlaceId} {_UserId} {_FType} {_DateStart.ToString("dd.MM.yyyy")} {_DateStart.TimeOfDay} {_DateFinish.ToString("dd.MM.yyyy")} {_DateFinish.TimeOfDay}";

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
            }
        }
    }
}

