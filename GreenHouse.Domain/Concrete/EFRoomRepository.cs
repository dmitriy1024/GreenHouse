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
                }
                return _context.Rooms;
            }
        }
    }
}
