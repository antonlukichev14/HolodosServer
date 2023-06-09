﻿using HolodosServer.Database;
using System;
using System.Collections.Generic;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных записи
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    static class DatabaseBookingManager
    {
        public static Booking[] DayRec(uint CityId, uint PlaceId, DateTime dt)
        {
            List<Booking> onDay = new List<Booking>();
            string[] lines = DatabaseBooking.GetString();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tempAr = lines[i].Split(' ');
                string[] dta = tempAr[5].Split('.');
                string[] tma = tempAr[6].Split(':');
                Booking tempBooking = new Booking(uint.Parse(tempAr[0]), uint.Parse(tempAr[1]), uint.Parse(tempAr[2]), tempAr[3], byte.Parse(tempAr[4]), new DateTime(int.Parse(dta[2]), int.Parse(dta[1]), int.Parse(dta[0]), int.Parse(tma[0]), int.Parse(tma[1]), int.Parse(tma[2])), int.Parse(tempAr[7]));

                if (tempBooking.Date.Date == dt.Date && tempBooking.CityId == CityId && tempBooking.PlaceId == PlaceId)
                {
                    onDay.Add(tempBooking);
                }
            }
            return onDay.ToArray();
        }

        public static Booking[] DayRec(DateTime dt)
        {
            List<Booking> onDay = new List<Booking>();
            string[] lines = DatabaseBooking.GetString();

            for (int i = 0; i < lines.Length; i++) 
            {
                string[] tempAr = lines[i].Split(' ');
                string[] dta = tempAr[5].Split('.');
                string[] tma = tempAr[6].Split(':'); 
                Booking tempBooking = new Booking(uint.Parse(tempAr[0]), uint.Parse(tempAr[1]), uint.Parse(tempAr[2]), tempAr[3], byte.Parse(tempAr[4]), new DateTime(int.Parse(dta[2]), int.Parse(dta[1]), int.Parse(dta[0]), int.Parse(tma[0]), int.Parse(tma[1]), int.Parse(tma[2])), int.Parse(tempAr[7]));

                if (tempBooking.Date.Date == dt.Date)
                {
                    onDay.Add(tempBooking);
                }
            }
            return onDay.ToArray();
        }

        public static Booking[] WeekRec(DateTime _dt)
        {
            DayOfWeek dayOfWeek = _dt.DayOfWeek;
            DateTime dt = new DateTime(_dt.Year, _dt.Month, _dt.Day, _dt.Hour, _dt.Minute, _dt.Second);
            dt.AddDays(-(int)dayOfWeek);
            string[] lines = DatabaseBooking.GetString();
            List<Booking> onWeek = new List<Booking>();

            for (int j = 0; j < 7; j++)
            {
                Booking[] bb = DayRec(dt);

                for(int i = 0; i < bb.Length; i++)
                {
                    onWeek.Add(bb[i]);
                }

                dt.AddDays(1);
            }

            return onWeek.ToArray();
            // функция получения всех записей на неделю, в виде массива
        }

        public static void BookingInBase(Booking OneRec)
        {
            DatabaseBooking.Add(OneRec.CityId, OneRec.PlaceId, OneRec.UserId, OneRec.FType, OneRec.Date, OneRec.Hours);

            // функция внесения бронироваания в базу данных
        }
    }
}
