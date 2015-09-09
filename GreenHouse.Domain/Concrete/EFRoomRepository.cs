using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GreenHouse.Domain.Concrete
{
    public class EFRoomRepository : IRoomRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Room> Rooms
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

                foreach (var item in _context.AdditEquipments)
                {
                    System.Diagnostics.Debug.WriteLine(item.Name);
                }

                foreach (var item in _context.Rooms)
                {
                    System.Diagnostics.Debug.WriteLine(item.Number);
                    foreach (var item2 in item.AdditEquipments)
                    {
                        System.Diagnostics.Debug.WriteLine(item2.Name);
                    }
                }

                foreach (var item in _context.AdditEquipments)
                {
                    System.Diagnostics.Debug.WriteLine(item.Name);
                    foreach (var item2 in item.Rooms)
                    {
                        System.Diagnostics.Debug.WriteLine(item2.Number);
                    }
                }
                return _context.Rooms;
            }
        }

        public IEnumerable<Room> GetRoomsByDate(DateTime date)
        {
            var begDate = date.Date;
            var endDate = date.AddDays(1);

            var reservatioms = _context.Reservations.Where(a => a.BeginTime > begDate && a.BeginTime < endDate);

            var rooms = from i in reservatioms
                        join fi in _context.Rooms on i.RoomId equals fi.Id
                        select fi;

            return rooms.ToList();
        }
    }
}
