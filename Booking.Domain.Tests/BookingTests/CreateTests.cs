using System;
using Booking.Domain.Model;
using Xunit;

namespace Booking.Domain.Tests.BookingTests
{
    public class CreateTests
    {
        [Fact]
        public void GivenStartTidIsDefault_Then_ThrowException()
        {
            // Assert
            Assert.ThrowsAny<ArgumentException>(() =>
                new Model.Booking(new DateTime(), DateTime.Now, new BookingCalendar()));
        }
    }
}