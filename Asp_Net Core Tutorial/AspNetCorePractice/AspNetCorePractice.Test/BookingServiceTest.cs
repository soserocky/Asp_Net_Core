using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Models.Entities;
using AspNetCorePractice.Models.Enums;
using AspNetCorePractice.Services.Contracts;
using AspNetCorePractice.Services.Implementations;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AspNetCorePractice.Test
{
    public class BookingServiceTest
    {
        private readonly IBookingService _bookingService;


        public BookingServiceTest()
        {
            var dbContextMock = new DbContextMock<AspNetCorePracticeDbContext>(new DbContextOptionsBuilder<AspNetCorePracticeDbContext>().Options);

            var dbContext = dbContextMock.Object;

            dbContextMock.CreateDbSetMock(p => p.Bookings, new List<Booking>() { 
                new Booking() { Id = 1, Email = "sabya9106@gmail.com", Room = 1, StartDate = new DateTime(2023, 02, 15), EndDate = new DateTime(2023, 02, 12) },
                new Booking() { Id = 2, Email = "sanjaysrinivas0172@gmail.com", Room = 1, StartDate = new DateTime(2023, 05, 15), EndDate = new DateTime(2023, 05, 16) },
                new Booking() { Id = 3, Email = "bombay.sangram@gmail.com", Room = 2, StartDate = new DateTime(2023, 04, 15), EndDate = new DateTime(2023, 04, 22) }
            });

            dbContextMock.CreateDbSetMock(p => p.Rooms, new List<Room>() {
                new Room() { Id = 1, Name = "101", Type = RoomType.Normal },
                new Room() { Id = 2, Name = "102", Type = RoomType.Normal },
                new Room() { Id = 3, Name = "103", Type = RoomType.Normal }
            });
            
            _bookingService = new BookingService(dbContextMock.Object);
        }


        [Fact]
        public void IsBookingAvailableTest()
        {
            var roomFinderDto = new RoomFinderDto() { NoOfRooms = 2, StartDate = new DateTime(2023, 05, 15), EndDate = new DateTime(2023, 05, 22), RoomType = RoomType.Normal };

            var expected = true;

            var actual = _bookingService.IsBookingAvailable(roomFinderDto);

            Assert.Equal(expected, actual);
        }
    }
}