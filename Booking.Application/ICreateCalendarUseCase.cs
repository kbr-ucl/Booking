using Booking.Application.Commands;

namespace Booking.Application
{
    public interface ICreateCalendarUseCase
    {
        void CreateCalendar(CreateCalendarRequest command);
    }
}