using System;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GreenHouse.Domain.Concrete
{
    public class EFReservationRepository : IReservationRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Reservation> GetReservationsByDate(DateTime date)
        {
            var begDate = date.Date;
            var endDate = date.AddDays(1);

            var reservations = _context.Reservations.Where(a => a.BeginTime > begDate && a.BeginTime < endDate);

            return reservations.ToList();
        }

        public void AddReservation(string userId, int roomId, DateTime beginTime, DateTime endTime, string purpose)
        {
            var room = _context.Rooms.Where(a => a.Id == roomId).ToList();
            
            var res = new Reservation()
            {
                AspNetUserId = userId,
                BeginTime = beginTime,
                EndTime = endTime,
                RoomId = room[0].Id,
                Purpose = purpose
            };

            _context.Reservations.Add(res);
            _context.SaveChanges();
        }
    }
}
