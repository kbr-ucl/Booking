using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Application.Persistance;
using Booking.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistance.Repositorys
{
    public class BookingCalendarRepository : IBookingCalendarRepository
    {
        private readonly BookingContext _context;

        public BookingCalendarRepository(BookingContext context)
        {
            _context = context;
        }

        public void AddBookingCalendar(BookingCalendar calendar)
        {
            _context.Calendars.Add(calendar);
        }

        public DbContext GetContext()
        {
            return _context;
        }

        BookingCalendar IBookingCalendarRepository.GetBookingCalendar(Guid id)
        {
            return _context.Calendars.Find(id);
        }

        List<BookingCalendar> IBookingCalendarRepository.GetBookingCalendars()
        {
            return _context.Calendars.ToList();
        }

        void IBookingCalendarRepository.UpdateBookingCalendar(BookingCalendar calendar)
        {
            if(!_context.Calendars.Any(a => a.Id == calendar.Id)) throw new Exception($"Calendar not found - Id: {calendar.Id}");
            _context.Calendars.Update(calendar);
        }
    }
}