using GreenHouse.Domain.Entities;
using System.Data.Entity;

namespace GreenHouse.Domain.Concrete
{
    public class EFDbContext : DbContext
    {   
        public DbSet<Room> Rooms { get; set; }
    }
}
