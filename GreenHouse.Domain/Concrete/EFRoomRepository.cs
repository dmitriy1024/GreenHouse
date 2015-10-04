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

        public bool Exists(string roomNumber)
        {
            var rooms = _context.Rooms.Where(a => String.Compare(a.Number, roomNumber, true) == 0);

            return rooms.Count() > 0;
        }

        public Room GetRoomByNumber(string roomNumber)
        {
            var rooms = _context.Rooms.Where(a => String.Compare(a.Number, roomNumber, true) == 0);

            if(rooms.Count() > 0)
            {
                return rooms.First();
            }
            else
            {
                return null;
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

        public bool AdditEquipmExists(string roomNumber, string additEquipmName)
        {
            var rooms = _context.Rooms.Where(a => String.Compare(a.Number, roomNumber, true) == 0);
            if(rooms.Count() > 0)
            {
                var room = rooms.First();
                foreach (var equip in room.AdditEquipments)
                {
                    if(String.Compare(equip.Name, additEquipmName, true) == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public void AddRoom(int selectedRoom, string capacity, string wifiOpt, string projectorOpt, string monitorOpt, string microphoneOpt)
        {
            var room = new Room()
            {
                Number = selectedRoom.ToString().Trim(),
                Capacity = Int32.Parse(capacity),
                Floor = 5
            };

            _context.Rooms.Add(room);
            _context.SaveChanges();
            var x = _context.Rooms.First(a => String.Compare(a.Number, selectedRoom.ToString(), true) == 0);
            var b = _context.AdditEquipments.First(a => String.Compare(a.Name, "wifi", true) == 0);
            if(wifiOpt != null)
                b.Rooms.Add(x);
            if (projectorOpt != null)
            {
                b = _context.AdditEquipments.First(a => String.Compare(a.Name, "projector", true) == 0);
                b.Rooms.Add(x);
            }
            if (monitorOpt != null)
            {
                b = _context.AdditEquipments.First(a => String.Compare(a.Name, "monitor", true) == 0);
                b.Rooms.Add(x);
            }
            if (microphoneOpt != null)
            {
                b = _context.AdditEquipments.First(a => String.Compare(a.Name, "microphone", true) == 0);
                b.Rooms.Add(x);
            }
            _context.SaveChanges();
        }


        //public void RemoveRoom(int selectedRoom)
        //{
        //    var currentRoom = _context.Rooms.First(a => String.Compare(a.Number, selectedRoom.ToString()) == 0);
        //    var additEquip = currentRoom.AdditEquipments.ToList();
        //    foreach (var item in additEquip)
        //    {
        //        currentRoom.AdditEquipments.Remove(item);
        //    }
        //    _context.SaveChanges();
        //    var reservations = currentRoom.Reservations.ToList();
        //    foreach (var item in reservations)
        //    {
        //        currentRoom.Reservations.Remove(item);
        //    }
        //    _context.SaveChanges();
        //    _context.Rooms.Remove(currentRoom);
        //    _context.SaveChanges();
        //}

        public void RemoveRoom(int selectedRoom)
        {
            var currentRoom = _context.Rooms.FirstOrDefault(a => String.Compare(a.Number, selectedRoom.ToString()) == 0);
            if (currentRoom != null)
            {
                _context.Entry(currentRoom).Collection(c => c.Reservations).Load();
                _context.Entry(currentRoom).Collection(c => c.AdditEquipments).Load();
                _context.Rooms.Remove(currentRoom);
                _context.SaveChanges();
            }               
        }
    }
}
