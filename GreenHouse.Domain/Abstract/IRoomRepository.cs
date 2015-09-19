using System;
using System.Collections.Generic;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        IDictionary<Room, IEnumerable<Reservation>> GetRoomsAndReservationsByDate(DateTime date);       
    }
}
