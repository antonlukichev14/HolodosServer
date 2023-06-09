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
        public uint CityId;
        public uint PlaceId;
        public string UserId; //Был ID, стал Login
        public byte FType;
        public int Date;
        public int Time;
        public int Hours;
        
        public Booking() { }

        public Booking(uint _BookingId, uint _CityId, uint _PlaceId, string _UserId, byte _FType, int _Date, int _Time, int _Hours)
        {
            BookingId = _BookingId;
            CityId = _CityId;
            PlaceId = _PlaceId;
            UserId = _UserId;
            FType = _FType;
            Date = _Date;
            Time = _Time;
            Hours = _Hours;
        }
    }
}
