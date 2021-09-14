using System.Collections.Generic;
using Xunit;
using Booking = Booking.Domain.Model.Booking;

namespace Booking.Domain.Tests.BookingTests
{
    public class IsOverlappingTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new Model.Booking();
            var expected = true;
            // Act

            var actual = sut.IsOverlapping(new List<Model.Booking>());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenBookingsHasOverlaps_ThenThrowException()
        {

        }
    }
}