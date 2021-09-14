using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Domain.Model
{
    public class Booking
    {
        // Dont use - for EF only
        public Booking()
        {
            
        }

        public Booking(DateTime startTid, DateTime slutTid)
        {
            if (startTid == default) throw new ArgumentException($"Starttid skal være udfyldt");
        }

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public bool IsOverlapping(List<Booking> otherBookings)
        {
            if (!CheckOverlap(otherBookings)) return false;
            return true;
        }

        private bool CheckOverlap(List<Booking> otherBookings)
        {
            return true;//throw new System.NotImplementedException();
        }
    }
}
