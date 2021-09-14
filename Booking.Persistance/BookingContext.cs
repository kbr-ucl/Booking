using Microsoft.EntityFrameworkCore;

namespace Booking.Persistance
{
    public class BookingContext : DbContext
    {
        public DbSet<Domain.Model.Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //PK, FK...
        }
    }
}