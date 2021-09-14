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
            StartTid = startTid;
            SlutTid = slutTid;
        }

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public bool IsOverlapping(List<Booking> otherBookings)
        {
            var result = otherBookings.Any(a => a.StartTid >= StartTid && StartTid <= a.SlutTid);
            //result = result || 
            return result;
        }


    }
}
