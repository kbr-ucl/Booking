using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Api.Contract.Dto;

namespace Booking.Api.Contract
{
    // api/Booking
    public interface IBookingService
    {
        // [HttpGet("{calenderId}")]
        Task<IEnumerable<BookingDto>> GetBookings(Guid calenderId);

        // [HttpGet("{calenderId}/{bookingId}")]
        public Task<BookingDto> GetBooking(Guid calenderId, Guid bookingId);

        // [HttpPost]
        public Task CreateBooking(BookingDto dto);
    }
}