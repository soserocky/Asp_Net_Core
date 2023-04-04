using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly AspNetCorePracticeDbContext _dbContext;
        public BookingService(AspNetCorePracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool IsBookingAvailable(RoomFinderDto roomFinderDto)
        {
            //Find unavailable rooms
            var bookings = _dbContext.Bookings.ToList();

            var notAllowedRooms = bookings.Where(booking => 
                (booking.StartDate <= roomFinderDto.StartDate && booking.EndDate >= roomFinderDto.EndDate) ||
                (booking.StartDate >= roomFinderDto.StartDate && booking.StartDate < roomFinderDto.EndDate) ||
                (booking.EndDate > roomFinderDto.StartDate && booking.EndDate <= roomFinderDto.EndDate)
            ).ToList();

            var rooms = _dbContext.Rooms.ToList();
            if (notAllowedRooms == null || !notAllowedRooms.Any())
            {
                if (rooms != null && rooms.Count >= roomFinderDto.NoOfRooms) return true;
            }
            else
            {
                var notAllowedRoomIds = notAllowedRooms.Select(r => r.Id).Distinct().ToList();
                var availableRooms = rooms.Where(room => !notAllowedRoomIds.Contains(room.Id)).ToList();

                if (availableRooms != null && availableRooms.Count >= roomFinderDto.NoOfRooms) return true;
            }
            
            return false;
        }
    }
}
