using System;
using Booking.Application.Commands;
using Booking.Application.Persistance;

namespace Booking.Application.Implementation
{
    public class CreateCalendarUseCase : ICreateCalendarUseCase
    {
        private readonly IBookingCalendarRepository _calendarRepository;

        public CreateCalendarUseCase(IBookingCalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }


        void ICreateCalendarUseCase.CreateCalendar(CreateCalendarRequest command)
        {
            throw new NotImplementedException();
        }
    }
}