using Booking.Application.Commands;

namespace Booking.Application
{
    public interface IUpdateCalendarUseCase
    {
        void UpdateCalendar(UpdateCalendarRequest updateCalendarRequest);
    }
}