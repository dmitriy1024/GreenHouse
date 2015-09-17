using System;
using System.Collections.Generic;

namespace GreenHouse.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public int RoomId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Purpose { get; set; }

        public virtual Room Room { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
