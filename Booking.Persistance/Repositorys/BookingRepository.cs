﻿using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Application.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Booking.Persistance.Repositorys
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;
        private IDbContextTransaction _transaction;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        List<Domain.Model.Booking> IBookingRepository.GetBookings(Guid calendarId)
        {
            return _context.Calendars.Include(a => a.Bookings).FirstOrDefault(a => a.Id == calendarId)?.Bookings ??
                   new List<Domain.Model.Booking>();
        }

        Domain.Model.Booking IBookingRepository.GetBooking(Guid bookingId)
        {
            return _context.Bookings.Include(a => a.Calendar).First(a => a.Id == bookingId);
        }

        void IRepository<Domain.Model.Booking>.Save(Domain.Model.Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
    }
}