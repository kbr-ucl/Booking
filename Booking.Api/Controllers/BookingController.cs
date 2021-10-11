using System;
using System.Collections.Generic;
using Booking.Api.Contract.Dto;
using Booking.Application;
using Booking.Application.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICreateBookingUseCase _createBookingUseCase;
        private readonly IGetBookingUseCase _getBookingUseCase;

        public BookingController(IGetBookingUseCase getBookingUseCase, ICreateBookingUseCase createBookingUseCase)
        {
            _getBookingUseCase = getBookingUseCase;
            _createBookingUseCase = createBookingUseCase;
        }

        // GET: api/<BookingController>
        [HttpGet("{calenderId}")]
        public IEnumerable<BookingDto> Get(Guid calenderId)
        {
            var model = _getBookingUseCase.GetBookings(new GetBookingRequest {CalendarId = calenderId});
            var dto = new List<BookingDto>();
            model.ForEach(a => dto.Add(new BookingDto
                {CalendarId = a.Calendar.Id, Id = a.Id, SlutTid = a.SlutTid, StartTid = a.StartTid}));
            return dto;
        }

        // GET api/<BookingController>/5
        [HttpGet("{calenderId}/{bookingId}")]
        public BookingDto Get(Guid calenderId, Guid bookingId)
        {
            var model = _getBookingUseCase.GetBooking(new GetBookingRequest
                {CalendarId = calenderId, BookingId = bookingId});
            var dto = new BookingDto
                {CalendarId = model.Calendar.Id, Id = model.Id, SlutTid = model.SlutTid, StartTid = model.StartTid};
            return dto;
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] BookingDto dto)
        {
            _createBookingUseCase.CreateBooking(new CreateBookingRequest
                {CalenderId = dto.CalendarId, SlutTid = dto.SlutTid, StartTid = dto.StartTid});
        }

        //// PUT api/<BookingController>/5
        //[HttpPut("{id}")]
        //public void Put(Guid id, [FromBody] BookingDto value)
        //{
        //}

        //// DELETE api/<BookingController>/5
        //[HttpDelete("{id}")]
        //public void Delete(Guid id)
        //{
        //}
    }
}