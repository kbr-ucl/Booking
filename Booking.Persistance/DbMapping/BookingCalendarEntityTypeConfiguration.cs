using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Persistance.DbMapping
{
    public class BookingCalendarEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Model.BookingCalendar>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.BookingCalendar> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder
                .HasMany(c => c.Bookings)
                .WithOne(e => e.Calendar);
        }
    }
}