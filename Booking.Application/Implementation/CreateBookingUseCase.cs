using System;
using Booking.Application.Commands;
using Booking.Application.Persistance;
using Crosscut.Persistance;

namespace Booking.Application.Implementation
{
    public class CreateBookingUseCase : ICreateBookingUseCase
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingCalendarRepository _calendarRepository;
        private readonly IUnitOfWork<IBookingRepository> _unitOfWork;

        public CreateBookingUseCase(IUnitOfWork<IBookingRepository> unitOfWork, IBookingRepository repository, IBookingCalendarRepository calendarRepository)
        {
            _repository = repository;
            _calendarRepository = calendarRepository;
            _unitOfWork = unitOfWork;
        }



        public void CreateBooking(CreateBookingRequest command)
        {
            _unitOfWork.BeginUnitOfWork();
            // Get Calendar
            var calendar = _calendarRepository.GetBookingCalendar(command.CalenderId);
            // Domain roules validation
            var otherBookings = _repository.GetBookings(calendar.Id);
            var booking = new Domain.Model.Booking(command.StartTid, command.SlutTid, calendar);
            if (booking.IsOverlapping(otherBookings)) throw new Exception($"Ny booking start: {command.StartTid}, slut:{command.SlutTid} i kalender: {calendar.Id} overlapper med en anden booking" );
            _repository.AddBooking(booking);
            // Ok
            _unitOfWork.CommitUnitOfWork();
        }
    }
}
