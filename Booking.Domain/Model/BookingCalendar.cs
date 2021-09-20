using System;
using System.Collections.Generic;

namespace Booking.Domain.Model
{
    public class BookingCalendar
    {
        public Guid Id { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}