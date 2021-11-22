using System;
using Booking.Application.Commands;
using Booking.Application.Persistance;
using Booking.Domain.Model;
using Crosscut.Persistance;

namespace Booking.Application.Implementation
{
    public class UpdateCalendarUseCase : IUpdateCalendarUseCase
    {
        private readonly IUnitOfWork<IBookingCalendarRepository> _unitOfWork;
        private readonly IBookingCalendarRepository _calendarRepository;

        public UpdateCalendarUseCase(IUnitOfWork<IBookingCalendarRepository> unitOfWork, IBookingCalendarRepository calendarRepository)
        {
            _unitOfWork = unitOfWork;
            _calendarRepository = calendarRepository;
        }


        void IUpdateCalendarUseCase.UpdateCalendar(UpdateCalendarRequest command)
        {
            var calendar = new BookingCalendar { Name = command.Name, Id = command.Id, Concurrency = command.Concurrency};
            _unitOfWork.BeginUnitOfWork();

            _calendarRepository.UpdateBookingCalendar(calendar);

            // Domain roules validation
            //var otherBookings = _repository.GetBookings(calendar.Id);
            //var booking = new Domain.Model.Booking(command.StartTid, command.SlutTid, calendar);
            //if (booking.IsOverlapping(otherBookings)) throw new Exception($"Ny booking start: {command.StartTid}, slut:{command.SlutTid} i kalender: {calendar.Id} overlapper med en anden booking");
            //_repository.AddBooking(booking);
            // Ok
            _unitOfWork.CommitUnitOfWork();
        }
    }
}