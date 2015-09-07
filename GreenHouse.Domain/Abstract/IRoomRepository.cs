using System.Linq;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }
    }
}
