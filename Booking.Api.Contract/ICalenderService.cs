using Booking.Api.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Api.Contract
{
    public interface ICalenderService
    {
        Task<List<CalendarDto>> GetCalendarsAsync();
        Task<CalendarDto> GetCalendarByIdAsync(Guid id);
        Task CreateCalendarAsync(CalendarDto calendar);
        Task UpdateCalendarAsync(CalendarDto calendar);
    }
}
