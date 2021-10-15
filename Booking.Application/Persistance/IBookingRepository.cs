using System;
using System.Collections.Generic;

namespace Booking.Application.Persistance
{
    public interface IBookingRepository : IRepository<Domain.Model.Booking>
    {
        List<Domain.Model.Booking> GetBookings(Guid calendarId);
        Domain.Model.Booking GetBooking(Guid bookingId);
    }
}