using System;
using System.Collections.Generic;
using GreenHouse.Domain.Entities;

namespace GreenHouse.Domain.Abstract
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        IDictionary<Room, IEnumerable<Reservation>> GetRoomsAndReservationsByDate(DateTime date);
        bool Exists(string roomNumber);
        Room GetRoomByNumber(string roomNumber);
        bool AdditEquipmExists(string roomNumber, string additEquipmName);

        void AddRoom(int selectedRoom, string capacity, string wifiOpt, string projectorOpt, string monitorOpt,
            string microphoneOpt);
    }
}
