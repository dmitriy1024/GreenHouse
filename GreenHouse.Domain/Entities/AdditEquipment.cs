using System.Collections.Generic;

namespace GreenHouse.Domain.Entities
{
    public class AdditEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
