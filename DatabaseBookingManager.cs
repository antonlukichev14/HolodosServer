using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных записи
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    static class DatabaseBookingManager
    {
        public static Booking[] WeekRec()
        {
            // функция получения всех записей на неделю, в виде массива
            Booking[] OnWeek = new Booking[] { };
            return OnWeek;
        }

        public static void BookingInBase(Booking OneRec)
        {
            // функция внесения бронироваания в базу данных
        }

        public Booking[] DayRec(Booking.CityId cityId, Booking.PlaceId placeId)
        {
            //функция возвращает все записи из опред. места, в виде массива
            Booking[] OnDay = new Booking[] { }
            return OnDay;
        }
    }
}
