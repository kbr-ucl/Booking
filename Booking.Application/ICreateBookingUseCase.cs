using Booking.Application.Commands;

namespace Booking.Application
{
    public interface ICreateBookingUseCase
    {
        void CreateBooking(CreateBookingRequest command);
    }
}