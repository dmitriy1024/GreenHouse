using System.Collections.Generic;

namespace GreenHouse.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
