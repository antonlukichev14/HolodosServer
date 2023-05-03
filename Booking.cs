using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolodosServer
{
    public class Booking
    {
        public uint BookingId;
        public int Date;
        public int Time;
        public uint UserId;

        public Booking() { }

        public Booking(uint _BookingId, int _Date, int _Time, uint _UserId)
        {
            BookingId = _BookingId;
            Date = _Date;
            Time = _Time;
            UserId = _UserId;
        }
    }
}
