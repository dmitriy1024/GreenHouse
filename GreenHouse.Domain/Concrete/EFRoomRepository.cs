using System;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GreenHouse.Domain.Concrete
{
    public class EFRoomRepository : IRoomRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Room> Rooms
        {
            get
            {
                return _context.Rooms.ToList();
            }
        }

        public IDictionary<Room, IEnumerable<Reservation>> GetRoomsAndReservationsByDate(DateTime date)
        {
            var rooms = _context.Rooms;
            var reservRep = new EFReservationRepository();
            var reservations = reservRep.GetReservationsByDate(date);

            var dictToReturn = new Dictionary<Room, IEnumerable<Reservation>>();

            foreach (var room in rooms)
            {
                var reservationsByRoom = reservations.Where(a => a.RoomId == room.Id);
                dictToReturn.Add(room, reservationsByRoom);
            }

            return dictToReturn;
        }
    }
}
