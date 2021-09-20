using System;
using System.Collections.Generic;

namespace Booking.Application.Persistance
{
    public interface IBookingRepository
    {
        public List<Domain.Model.Booking> GetBookings(Guid calendarId);

        public void Save(Domain.Model.Booking booking);
    }
}