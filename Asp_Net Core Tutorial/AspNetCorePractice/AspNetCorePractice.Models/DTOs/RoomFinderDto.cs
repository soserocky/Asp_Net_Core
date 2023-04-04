using AspNetCorePractice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Models.DTOs
{
    public class RoomFinderDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomType RoomType { get; set; }
        public int NoOfRooms { get; set; }
    }
}
