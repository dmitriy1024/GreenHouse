using System.Data.Entity;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AdditEquipment> AdditEquipments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasMany(c => c.Reservations).WithRequired(f => f.Room);
            modelBuilder.Entity<AspNetUser>().HasMany(c => c.Reservations).WithRequired(f => f.AspNetUser);

            modelBuilder.Entity<Room>().HasMany(c => c.AdditEquipments).WithMany(p => p.Rooms).
              Map(
               m =>
               {
                   m.MapLeftKey("RoomId");
                   m.MapRightKey("AdditEquipmentId");
                   m.ToTable("AdditEquipmentsRooms");
               });
        }
    }
}
