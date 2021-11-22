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
    public class CalendarController : ControllerBase
    {
        private readonly ICreateCalendarUseCase _createCalendarUseCase;
        private readonly IUpdateCalendarUseCase _updateCalendarUseCase;
        private readonly IGetCalendarUseCase _getCalendarUseCase;

        public CalendarController(IGetCalendarUseCase getCalendarUseCase, ICreateCalendarUseCase createCalendarUseCase, IUpdateCalendarUseCase updateCalendarUseCase)
        {
            _getCalendarUseCase = getCalendarUseCase;
            _createCalendarUseCase = createCalendarUseCase;
            _updateCalendarUseCase = updateCalendarUseCase;
        }

        // GET: api/<CalendarController>
        [HttpGet]
        public IEnumerable<CalendarDto> Get()
        {
            var model = _getCalendarUseCase.GetCalendars();
            var dto = new List<CalendarDto>();
            model.ForEach(a => dto.Add(new CalendarDto
                {Id = a.Id, Name = a.Name, Concurrency = a.Concurrency}));
            return dto;
        }

        // GET api/<CalendarController>/5
        [HttpGet("{id}")]
        public CalendarDto Get(Guid id)
        {
            var model = _getCalendarUseCase.GetCalendar(new GetCalendarRequest {CalendarId = id});
            var dto = new CalendarDto { Id = model.Id, Name = model.Name, Concurrency = model.Concurrency };
            return dto;
        }

        // POST api/<CalendarController>
        [HttpPost]
        public void Post([FromBody] CalendarDto value)
        {
            _createCalendarUseCase.CreateCalendar(new CreateCalendarRequest{Name = value.Name});
        }

        // PUT api/<CalendarController>/5
        [HttpPut]
        public void Put([FromBody] CalendarDto value)
        {
            _updateCalendarUseCase.UpdateCalendar(new UpdateCalendarRequest{Id = value.Id, Name = value.Name, Concurrency = value.Concurrency});
        }

        //// DELETE api/<CalendarController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}