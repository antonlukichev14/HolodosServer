using HolodosServer.Database;
using System;
using System.Collections.Generic;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных записи
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    static class DatabaseBookingManager
    {

        public static List<Booking> DayRec(DateTime dt)
        {
            List<Booking> onDay = new List<Booking>();
            string[] lines = DatabaseBooking.GetString();

            for (int i = 1; i < lines.Length; i++) // с 1 ибо первая строка это названия колонок
            {

                string[] tempAr = lines[i].Split(' ');
                if (DateTime.Parse(tempAr[5]).Date == dt.Date)
                {

                    Booking tempBooking = new Booking(uint.Parse(tempAr[0]), uint.Parse(tempAr[1]), uint.Parse(tempAr[2]), uint.Parse(tempAr[3]), byte.Parse(tempAr[4]), DateTime.Parse(tempAr[5]), DateTime.Parse(tempAr[6]));
                    onDay.Add(tempBooking);

                }
            }
            return onDay;

        }
        public static List<List<Booking>> WeekRec(DateTime dt)
        {
            string[] lines = DatabaseBooking.GetString();
            List<List<Booking>> onWeek = new List<List<Booking>>();

            for (int j = 0; j < 7; j++)
            {
                onWeek.Add(DayRec(dt));
                dt.AddDays(1);
            }

            return onWeek;











            // функция получения всех записей на неделю, в виде массива

        }

        public static void BookingInBase(Booking OneRec)
        {

            DatabaseBooking.Add(OneRec.BookingId, OneRec.CityId, OneRec.PlaceId, OneRec.UserId, OneRec.FType, OneRec.DateStart, OneRec.DateFinish);


            // функция внесения бронироваания в базу данных
        }

        public static Booking[] DayRec(uint cityId, uint placeId, int date)
        {
            //функция возвращает все записи из опред. места, в виде массива
            Booking[] OnDay = new Booking[] { };
            return OnDay;
        }
    }
}
