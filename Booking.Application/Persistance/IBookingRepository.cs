using System;
using System.Collections.Generic;
using Crosscut.Persistance;

namespace Booking.Application.Persistance
{
    public interface IBookingRepository : IRepository
    {
        List<Domain.Model.Booking> GetBookings(Guid calendarId);
        Domain.Model.Booking GetBooking(Guid bookingId);
        void AddBooking(Domain.Model.Booking booking);
    }
}