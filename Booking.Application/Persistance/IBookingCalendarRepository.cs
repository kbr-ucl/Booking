using System;
using System.Collections.Generic;
using Booking.Domain.Model;
using Crosscut.Persistance;

namespace Booking.Application.Persistance
{
    public interface IBookingCalendarRepository : IRepository
    {
        public BookingCalendar GetBookingCalendar(Guid id);
        List<BookingCalendar> GetBookingCalendars();
        void AddBookingCalendar(BookingCalendar calendar);
        void UpdateBookingCalendar(BookingCalendar calendar);
    }
}