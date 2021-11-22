using System;

namespace Booking.Application.Commands
{
    public class UpdateCalendarRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Concurrency { get; set; }
    }
}