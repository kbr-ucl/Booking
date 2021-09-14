using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application
{
    public interface IBookingRepository
    {
        public List<Domain.Model.Booking> GetBookings();

        public void Save(Domain.Model.Booking booking);
    }
}
