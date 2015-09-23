using System;
using System.Collections.Generic;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetReservationsByDate(DateTime date);
        void AddReservation(string userId, int roomId, DateTime beginTime, DateTime endTime, string purpose);
        void DelReservation(string userId, int roomId, DateTime beginTime);
        IEnumerable<Reservation> GetRoomReservationsByDate(string roomNumber, DateTime date);
        //IEnumerable<Reservation> GetRoomReservationsByDate(int roomId, DateTime date);
    }
}
