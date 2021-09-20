using System;
using Booking.Application.Persistance;
using Booking.Domain.Model;

namespace Booking.Persistance.Repositorys
{
    public class BookingCalendarRepository : IBookingCalendarRepository
    {
        private readonly BookingContext _context;

        public BookingCalendarRepository(BookingContext context)
        {
            _context = context;
        }

        BookingCalendar IBookingCalendarRepository.GetBookingCalendar(Guid id)
        {
            return _context.Calendars.Find(id);
        }
    }
}