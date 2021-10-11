using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Booking.Api.Contract;
using Booking.Api.Contract.Dto;
using Microsoft.Extensions.Options;

namespace Booking.Mvc.Infrastructure.BookingApi
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
    public class BookingService : IBookingService
    {
        private readonly BookingServiceConfiguration _apiConfiguration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public BookingService(IOptions<ApiConfiguration> options, IHttpClientFactory httpClientFactory)
        {
            _apiConfiguration = options.Value.BookingServiceConfiguration;

            // https://code-maze.com/using-httpclientfactory-in-asp-net-core-applications/
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_apiConfiguration.BaseUrl);
        }

        async Task IBookingService.CreateBooking(BookingDto dto)
        {
            throw new NotImplementedException();
        }

        async Task<BookingDto> IBookingService.GetBooking(Guid calenderId, Guid bookingId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<BookingDto>> IBookingService.GetBookings(Guid calenderId)
        {
            // https://code-maze.com/using-httpclientfactory-in-asp-net-core-applications/
            using (var response = await _httpClient.GetAsync($"{_apiConfiguration.ServiceUrl}/{calenderId}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<BookingDto>>(stream, _options);
            }
        }
    }
}