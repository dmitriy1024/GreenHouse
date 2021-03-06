﻿using System;
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
        IDictionary<DateTime, IEnumerable<Reservation>> GetRoomWeekReservationsByDate(string roomNumber, DateTime date);
        void AddBlock(string userId, int roomId, DateTime beginTime, DateTime endTime);
        void DelReservationByAdmin(int roomId, DateTime beginTime);
    }
}
