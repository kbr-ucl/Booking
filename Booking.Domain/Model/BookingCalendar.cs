using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Booking.Domain.Model
{
    public class BookingCalendar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
  
        public byte[] Concurrency { get; set; }   
        public List<Booking> Bookings { get; set; } = new();
    }
}