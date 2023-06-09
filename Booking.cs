using System;

namespace HolodosServer
{
    public class Booking
    {
        public uint BookingId;
        public uint CityId;
        public uint PlaceId;
        public string UserId;
        public byte FType;
        public DateTime Date;
        public int Hours;

        public Booking() { }

        public Booking(uint _BookingId, uint _CityId, uint _PlaceId, string _UserId, byte _FType, DateTime _Date, int _Hours)
        {
            BookingId = _BookingId;
            CityId = _CityId;
            PlaceId = _PlaceId;
            UserId = _UserId;
            FType = _FType;
            Date = _Date;
            Hours = _Hours;
        }
    }
}
