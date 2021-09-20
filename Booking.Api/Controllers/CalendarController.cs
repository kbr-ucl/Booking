using System;
using System.Collections.Generic;
using Booking.Api.Dto;
using Booking.Application;
using Booking.Application.Commands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICreateCalendarUseCase _createCalendarUseCase;
        private readonly IGetCalendarUseCase _getCalendarUseCase;

        public CalendarController(IGetCalendarUseCase getCalendarUseCase, ICreateCalendarUseCase createCalendarUseCase)
        {
            _getCalendarUseCase = getCalendarUseCase;
            _createCalendarUseCase = createCalendarUseCase;
        }

        // GET: api/<CalendarController>
        [HttpGet]
        public IEnumerable<CalendarDto> Get()
        {
            var model = _getCalendarUseCase.GetCalendars();
            var dto = new List<CalendarDto>();
            model.ForEach(a => dto.Add(new CalendarDto
                {Id = a.Id}));
            return dto;
        }

        // GET api/<CalendarController>/5
        [HttpGet("{id}")]
        public CalendarDto Get(Guid id)
        {
            var model = _getCalendarUseCase.GetCalendar(new GetCalendarRequest {CalendarId = id});
            var dto = new CalendarDto {Id = model.Id};
            return dto;
        }

        // POST api/<CalendarController>
        [HttpPost]
        public void Post([FromBody] CalendarDto value)
        {
            _createCalendarUseCase.CreateCalendar(new CreateCalendarRequest());
        }

        //// PUT api/<CalendarController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CalendarController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}