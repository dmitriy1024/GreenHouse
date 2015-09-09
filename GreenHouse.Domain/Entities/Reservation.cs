using System;

namespace GreenHouse.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Purpose { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
