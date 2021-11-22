using Booking.Application.Commands;
using Booking.Application.Persistance;
using Booking.Domain.Model;
using Crosscut.Persistance;

namespace Booking.Application.Implementation;

public class CreateCalendarUseCase : ICreateCalendarUseCase
{
    private readonly IBookingCalendarRepository _calendarRepository;
    private readonly IUnitOfWork<IBookingCalendarRepository> _unitOfWork;

    public CreateCalendarUseCase(IUnitOfWork<IBookingCalendarRepository> unitOfWork,
        IBookingCalendarRepository calendarRepository)
    {
        _unitOfWork = unitOfWork;
        _calendarRepository = calendarRepository;
    }


    void ICreateCalendarUseCase.CreateCalendar(CreateCalendarRequest command)
    {
        var calendar = new BookingCalendar {Name = command.Name};
        _unitOfWork.BeginUnitOfWork();
        _calendarRepository.AddBookingCalendar(calendar);
        _unitOfWork.CommitUnitOfWork();
    }
}