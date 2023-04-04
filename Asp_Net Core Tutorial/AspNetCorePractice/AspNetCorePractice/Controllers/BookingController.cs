using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePractice.Presentation.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("/findroomavailability")]
        public ActionResult RoomAvailability()
        {
            return View();
        }
        
        [HttpPost("/checkroomavailability")]
        public ActionResult CheckRoomAvailability(RoomFinderDto details)
        {
            var response = _bookingService.IsBookingAvailable(details);
            ViewData["IsBookingAvailable"] = response ? "Yes" : "No";
            return View();
        }
    }
}
