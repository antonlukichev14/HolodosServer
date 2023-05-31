using System;

namespace HolodosServer
{
    public class Booking
    {
        public uint BookingId;
        public uint CityId;
        public uint PlaceId;
        public uint UserId;
        public byte FType;
        public DateTime DateStart;
        public DateTime DateFinish;




        public Booking() { }

        public Booking(uint _BookingId, uint _CityId, uint _PlaceId, uint _UserId, byte _FType, DateTime _DateStart, DateTime _DateFinish)
        {
            BookingId = _BookingId;
            CityId = _CityId;
            PlaceId = _PlaceId;
            UserId = _UserId;
            FType = _FType;
            DateStart = _DateStart;
            DateFinish = _DateFinish;

        }
    }
}
