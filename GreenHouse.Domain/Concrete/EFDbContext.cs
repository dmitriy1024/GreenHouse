using GreenHouse.Domain.Entities;
using System.Data.Entity;

namespace GreenHouse.Domain.Concrete
{
    public class EFDbContext : DbContext
    {   
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasMany(c => c.Reservations).WithRequired(f => f.Room);
            modelBuilder.Entity<User>().HasMany(c => c.Reservations).WithRequired(f => f.User);
        }
    }
}
