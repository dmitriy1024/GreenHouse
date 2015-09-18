using System;
using System.Collections.Generic;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetReservationsByDate(DateTime date);
        void AddReservation(string userId, string roomNum, DateTime beginTime, DateTime endTime, string purpose);
    }
}
