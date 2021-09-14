using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application
{
    public class CreateBookingUseCase : ICreateBookingUseCase
    {
        private readonly IBookingRepository _repository;

        public CreateBookingUseCase(IBookingRepository repository)
        {
            _repository = repository;
        }



        public void CreateBooking(BookingCommand command)
        {
            // Domain roules validation
            var booking = new Domain.Model.Booking(command.StartTid, command.SlutTid);
            var otherBookings = _repository.GetBookings();
            if (booking.IsOverlapping(otherBookings)) throw new Exception("");

            // Ok
            _repository.Save(booking);
        }
    }

    public class BookingCommand
    {
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }


}
