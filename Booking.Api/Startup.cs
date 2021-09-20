using Booking.Application;
using Booking.Application.Implementation;
using Booking.Application.Persistance;
using Booking.Persistance;
using Booking.Persistance.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Booking.Api
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
            services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            ApplicationIocConfig(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Booking.Api", Version = "v1"});
            });
        }

        /// <summary>
        /// Opsætning af IoC ifht. domain logikken
        /// </summary>
        /// <param name="services"></param>
        private void ApplicationIocConfig(IServiceCollection services)
        {
            services.AddScoped<ICreateBookingUseCase, CreateBookingUseCase>();
            services.AddScoped<IGetBookingUseCase, GetBookingUseCase>();
            services.AddScoped<IBookingRepository, BookingRepository>();


            services.AddScoped<ICreateCalendarUseCase, CreateCalendarUseCase>();
            services.AddScoped<IGetCalendarUseCase, GetCalendarUseCase>();
            services.AddScoped<IBookingCalendarRepository, BookingCalendarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}