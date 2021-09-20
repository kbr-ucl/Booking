using System;
using Booking.Domain.Model;

namespace Booking.Application.Persistance
{
    public interface IBookingCalendarRepository
    {
        public BookingCalendar GetBookingCalendar(Guid id);
    }
}