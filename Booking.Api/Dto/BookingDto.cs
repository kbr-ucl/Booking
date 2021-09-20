using System;

namespace Booking.Api.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid CalendarId { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }
}