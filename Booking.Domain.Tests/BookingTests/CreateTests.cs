using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Domain.Tests.BookingTests
{
    public class CreateTests
    {
 
        [Fact]
        public void GivenStartTidIsDefault_Then_ThrowException()
        {
             // Assert
             Assert.ThrowsAny<ArgumentException>(() => new Model.Booking(new DateTime(), DateTime.Now));
        }
    }
}
