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

        public void DelReservation(string userId, int roomId, DateTime beginTime)
        {
            var reserv = _context.Reservations.
                            Where(a => String.Compare(a.AspNetUserId, userId, false) == 0 && a.RoomId == roomId && a.BeginTime == beginTime);
            if(reserv.Count() > 0)
            {
                var resToDel = reserv.First();
                _context.Reservations.Remove(resToDel);
                _context.SaveChanges();
            }            
        }

        public IEnumerable<Reservation> GetRoomReservationsByDate(string roomNumber, DateTime date)
        {
            var begDate = date.Date;
            var endDate = date.AddDays(1);

            var reservations = _context.Reservations.Where(a => a.BeginTime > begDate && a.BeginTime < endDate);
            var roomReservations = reservations.Where(a => String.Compare(a.Room.Number, roomNumber, true) == 0);

            return roomReservations.ToList();
        }

        public IDictionary<DateTime, IEnumerable<Reservation>> GetRoomWeekReservationsByDate(string roomNumber, DateTime date)
        {
            var week = GetWeekByDay(date);
            var weekReservations = new Dictionary<DateTime, IEnumerable<Reservation>>();

            if(week == null)
            {
                return weekReservations;
            }
            else
            {
                foreach (var day in week)
                {
                    weekReservations.Add(day, GetReservationsByDate(day).Where(a => String.Compare(a.Room.Number, roomNumber, true) == 0));
                }

                return weekReservations;
            }
        }

        private DateTime[] GetWeekByDay(DateTime date)
        {
            int dayNumber = 0;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayNumber = 1;
                    break;
                case DayOfWeek.Tuesday:
                    dayNumber = 2;
                    break;
                case DayOfWeek.Wednesday:
                    dayNumber = 3;
                    break;
                case DayOfWeek.Thursday:
                    dayNumber = 4;
                    break;
                case DayOfWeek.Friday:
                    dayNumber = 5;
                    break;
                case DayOfWeek.Saturday:
                    dayNumber = 6;
                    break;
                case DayOfWeek.Sunday:
                    dayNumber = 7;
                    break;
            }

            if(dayNumber == 0)
            {
                return new DateTime[0];
            }
            else
            {
                var week = new DateTime[7];
                int addDayNum = -dayNumber + 1;
                for (int i = 0; i < 7; i++)
                {
                    week[i] = date.AddDays(addDayNum++);
                }

                return week;
            }
        }
    }
}
