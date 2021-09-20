using System.Collections.Generic;
using Booking.Application.Commands;
using Booking.Application.Persistance;

namespace Booking.Application.Implementation
{
    public class GetBookingUseCase : IGetBookingUseCase
    {
        private readonly IBookingRepository _repository;

        public GetBookingUseCase(IBookingRepository repository)
        {
            _repository = repository;
        }

        Domain.Model.Booking IGetBookingUseCase.GetBooking(GetBookingRequest command)
        {
            return _repository.GetBooking(command.BookingId);
        }

        List<Domain.Model.Booking> IGetBookingUseCase.GetBookings(GetBookingRequest command)
        {
            return _repository.GetBookings(command.CalendarId);
        }
    }
}