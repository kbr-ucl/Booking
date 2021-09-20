using System;

namespace Booking.Application.Commands
{
    public class GetBookingRequest
    {
        public Guid CalendarId { get; set; }
        public Guid BookingId { get; set; }
    }
}