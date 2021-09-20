using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Application.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistance.Repositorys
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        List<Domain.Model.Booking> IBookingRepository.GetBookings(Guid calendarId)
        {
            return _context.Calendars.Include(a => a.Bookings).FirstOrDefault(a => a.Id == calendarId)?.Bookings ??
                   new List<Domain.Model.Booking>();
        }

        void IBookingRepository.Save(Domain.Model.Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        Domain.Model.Booking IBookingRepository.GetBooking(Guid bookingId)
        {
            throw new NotImplementedException();
        }
    }
}