using Booking.Api.Contract;
using Booking.Mvc.Infrastructure;
using Booking.Mvc.Infrastructure.BookingApi;
using Booking.Mvc.Infrastructure.CalenderService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Booking.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Load af IHttpClientFactory : https://code-maze.com/using-httpclientfactory-in-asp-net-core-applications/
            services.AddHttpClient();

            // Load af Api konfiguration fra settings : https://docs.microsoft.com/en-us/dotnet/core/extensions/options
            services.Configure<ApiConfiguration>(
                Configuration.GetSection("ApiConfiguration"));

            // Load af IBooking service
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICalenderService, CalenderServiceProxy>();


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}