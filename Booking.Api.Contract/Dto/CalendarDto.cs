using System;

namespace Booking.Api.Contract.Dto
{
    public class CalendarDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Concurrency { get; set; }
    }
}