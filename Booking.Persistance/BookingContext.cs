using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistance
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        public DbSet<Domain.Model.Booking> Bookings { get; set; }
        public DbSet<Domain.Model.BookingCalendar> Calendars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}