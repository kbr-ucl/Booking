using System.Collections.Generic;
using Booking.Application.Commands;

namespace Booking.Application
{
    public interface IGetBookingUseCase
    {
        Domain.Model.Booking GetBooking(GetBookingRequest command);
        List<Domain.Model.Booking> GetBookings(GetBookingRequest command);
    }
}