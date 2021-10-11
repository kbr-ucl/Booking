# MVC -> API



## Settings

### Booking -> Booking.Api

Properties -> launchSettings.json

"applicationUrl": "https://localhost:5001;http://localhost:5000",



### Booking.Mvc

#### Properties -> launchSettings.json

"applicationUrl": "https://localhost:6001;http://localhost:6000",

#### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ApiConfiguration": {
    "BookingServiceConfiguration": {
      "BaseUrl": "https://localhost:5001",
      "ServiceUrl": "/api/Booking"
    }
  }
}
```



#### Startup.cs

```c#
            // Load af Api konfiguration fra settings : https://docs.microsoft.com/en-us/dotnet/core/extensions/options
            services.Configure<ApiConfiguration>(
                Configuration.GetSection("ApiConfiguration"));
```



#### Booking.Mvc.Infrastructure -> ApiConfiguration.cs

```c#
namespace Booking.Mvc.Infrastructure
{
    public class ApiConfiguration
    {
        public BookingServiceConfiguration BookingServiceConfiguration { get; set; }
    }
}
```

#### Booking.Mvc.Infrastructure -> BookingApi -> BookingServiceConfiguration.cs

```c#
    public class BookingServiceConfiguration
    {
        public string BaseUrl { get; set; }
        public string ServiceUrl { get; set; }
    }
```

## MVC -> API communication
### API Contract
#### Booking.Api.Contract -> IBooking.cs

```c#
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
```

#### Booking.Api.Contract -> Dto -> BookingDto.cs

```c#
namespace Booking.Api.Contract.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid CalendarId { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }
}
```

### Booking.Mvc.Infrastructure
#### BookingApi -> BookingService.cs

```c#
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
```



### Booking.Mvc
#### Controllers -> HomeController.cs

```c#
    public class HomeController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var data = _bookingService.GetBookings(Guid.Parse("6403729F-4D0C-4129-A066-BBA105FF5962")).Result;
            return View();
        }
```





## Multiple Startup
Solution properties:

- Set Booking.Api to "start"
- Set Booking.Mvc to "start" 