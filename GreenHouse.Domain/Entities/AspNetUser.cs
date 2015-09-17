using System.Collections.Generic;

namespace GreenHouse.Domain.Entities
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
