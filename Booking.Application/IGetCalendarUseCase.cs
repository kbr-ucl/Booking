using System.Collections.Generic;
using Booking.Application.Commands;
using Booking.Domain.Model;

namespace Booking.Application
{
    public interface IGetCalendarUseCase
    {
        BookingCalendar GetCalendar(GetCalendarRequest command);
        List<BookingCalendar> GetCalendars();
    }
}