using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Domain.Model
{
    public class Booking
    {
        public Guid Id { get; set;}
        public BookingCalendar Calendar { get; set; }
        // Dont use - for EF only
        public Booking()
        {
            
        }

        public Booking(DateTime startTid, DateTime slutTid, BookingCalendar calendar)
        {
            Id = Guid.NewGuid();
            Calendar = calendar;


            if (startTid == default) throw new ArgumentException($"Starttid skal være udfyldt");
            StartTid = startTid;
            SlutTid = slutTid;

            calendar.Bookings.Add(this);
        }

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public bool IsOverlapping(List<Booking> otherBookings)
        {
            var result = otherBookings.Except(new []{this}).Any(a => a.StartTid >= StartTid && StartTid <= a.SlutTid);
            //result = result || 
            return result;
        }
    }
}
