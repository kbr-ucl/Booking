using System.Collections.Generic;
using Booking.Application.Commands;
using Booking.Application.Persistance;
using Booking.Domain.Model;

namespace Booking.Application.Implementation
{
    public class GetCalendarUseCase : IGetCalendarUseCase
    {
        private readonly IBookingCalendarRepository _calendarRepository;

        public GetCalendarUseCase(IBookingCalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        BookingCalendar IGetCalendarUseCase.GetCalendar(GetCalendarRequest command)
        {
            return _calendarRepository.GetBookingCalendar(command.CalendarId);
        }

        List<BookingCalendar> IGetCalendarUseCase.GetCalendars()
        {
            return _calendarRepository.GetBookingCalendars();
        }
    }
}