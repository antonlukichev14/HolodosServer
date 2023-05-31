using System;

namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {



            //DateTime one = new DateTime(2023, 11, 6, 03, 11, 01); //03 11 01
            //DateTime two = new DateTime(2023, 11, 6, 04, 21, 34); //04 21 34
            DateTime dt = new DateTime(2022, 05, 11, 02, 12, 01); //02 12 01
            //DateTime DT = new DateTime(2024, 12, 6, 1, 32, 37);
            //DateTime DT2 = new DateTime(2024, 12, 6, 1, 32, 37);
            //Booking b1 = new Booking(1, 2, 3, 4, 5, one, DT);
            //Booking b2 = new Booking(1, 2, 3, 4, 5, two, DT);
            //Booking b3 = new Booking(1, 2, 3, 4, 5, DT2, DT);
            //DatabaseBookingManager.BookingInBase(b1);
            //DatabaseBookingManager.BookingInBase(b2);
            //DatabaseBookingManager.BookingInBase(b3);

            //for (int j = 0; j < 100; j++)
            //{
            //    DateTime start = new DateTime(2022, 1, 1);
            //    Random gen = new Random();
            //    int range = (DateTime.Today - start).Days;
            //    DateTime randomDate = start.AddDays(gen.Next(range));

            //    Random gen1 = new Random();
            //    int range1 = (DateTime.Today - start).Days;
            //    DateTime randomDate1 = start.AddDays(gen1.Next(range1));



            //    Booking b2 = new Booking(1, 2, 3, 4, 5, randomDate, randomDate1);
            //    DatabaseBookingManager.BookingInBase(b2);
            //}
            var aaa = DatabaseBookingManager.WeekRec(dt);
            Console.WriteLine(dt);
            Console.WriteLine("\n\n\n");
            int i = 0;
            foreach (var item in aaa)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                    i++;
                }



            }
            Console.WriteLine(i);






        }
    }
}
