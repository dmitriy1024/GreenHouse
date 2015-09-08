using System.Collections.Generic;

namespace GreenHouse.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
