using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Linq;

namespace GreenHouse.Domain.Concrete
{
    public class EFRoomRepository : IRoomRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IQueryable<Room> Rooms
        {
            get
            {
                foreach (var item in _context.Rooms)
                {
                    System.Diagnostics.Debug.WriteLine(item.Number);
                    foreach (var item2 in item.Reservations)
                    {
                        System.Diagnostics.Debug.WriteLine(item2.BeginTime);
                    }
                }

                foreach (var item in _context.Users)
                {
                    System.Diagnostics.Debug.WriteLine(item.Email);
                    foreach (var item2 in item.Reservations)
                    {
                        System.Diagnostics.Debug.WriteLine(item2.BeginTime);
                    }
                }
                return _context.Rooms;
            }
        }
    }
}
