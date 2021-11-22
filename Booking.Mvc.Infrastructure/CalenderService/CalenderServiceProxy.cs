using Booking.Api.Contract;
using Booking.Api.Contract.Dto;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Booking.Mvc.Infrastructure.CalenderService
{
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
    public class CalenderServiceProxy : ICalenderService
    {

        private readonly HttpClient _httpClient;

        public CalenderServiceProxy(HttpClient httpClient)
        {

            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://localhost:5001");

            // using Microsoft.Net.Http.Headers;
            // The GitHub API requires two headers.
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/vnd.github.v3+json");
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "HttpRequestsSample");
        }

        public Task<CalendarDto> GetCalendarByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CalendarDto> GetCalendars()
        {
            throw new NotImplementedException();
        }



        public async Task<List<CalendarDto>> GetCalendarsAsync() =>
            await _httpClient.GetFromJsonAsync<List<CalendarDto>>(
                "api/Calendar");
    }
}

