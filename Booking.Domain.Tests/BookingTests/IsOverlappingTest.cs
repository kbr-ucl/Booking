using System;
using System.Collections.Generic;
using Booking.Domain.Model;
using Xunit;

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
        public void GivenBookingsHasOverlaps_ThenReturnFalse()
        {
            // Arrange
            var sut = new Model.Booking(
                new DateTime(2021, 9, 1), 
                new DateTime(2021, 9, 5),
                new BookingCalendar());

            var otherBookings = new List<Model.Booking>(new[]
                {new Model.Booking(
                    new DateTime(2021, 10, 1), 
                    new DateTime(2021, 10, 5),
                    new BookingCalendar())});
            var expected = false;

            // Act
            var actual = sut.IsOverlapping(otherBookings);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenBookingsHasOverlaps2_ThenReturnTrue()
        {
            // Arrange
            var sut = new Model.Booking(
                new DateTime(2021, 9, 1),
                new DateTime(2021, 9, 5),
                new BookingCalendar());

            var otherBookings = new List<Model.Booking>(new[]
            {new Model.Booking(
                new DateTime(2021, 9, 2),
                new DateTime(2021, 10, 6),
                new BookingCalendar())});
            var expected = true;

            // Act
            var actual = sut.IsOverlapping(otherBookings);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}