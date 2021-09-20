using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Persistance.DbMapping
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Model.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.StartTid)
                .IsRequired();

            builder
                .Property(b => b.SlutTid)
                .IsRequired();
        }
    }
}