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
    }
}
