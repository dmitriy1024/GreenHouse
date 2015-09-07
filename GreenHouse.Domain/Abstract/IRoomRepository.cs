using System.Linq;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }
    }
}
