using System;
using GreenHouse.Domain.Entities;
using System.Collections.Generic;

namespace GreenHouse.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        IEnumerable<Reservation> GetReservationsByDate(DateTime date);
    }
}
