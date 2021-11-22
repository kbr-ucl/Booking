using Booking.Api.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Api.Contract
{
    public interface ICalenderService
    { 
        List<CalendarDto> GetCalendars();
        Task<List<CalendarDto>> GetCalendarsAsync();
        Task<CalendarDto> GetCalendarByIdAsync(Guid id);
    }
}
