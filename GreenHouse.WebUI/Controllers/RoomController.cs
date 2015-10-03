using GreenHouse.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GreenHouse.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private IReservationRepository _reservationRepository;
        private IRoomRepository _roomRepository;

        public RoomController(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        [HttpPost]
        public ActionResult Index(string roomNumber)
        {
            if(_roomRepository.Exists(roomNumber))
            {
                ViewBag.RoomNumber = roomNumber;
                ViewBag.Places = _roomRepository.GetRoomByNumber(roomNumber).Capacity;
                ViewBag.Wifi = false;
                ViewBag.Projector = false;
                ViewBag.Monitor = false;
                ViewBag.Microphone = false;
                foreach (var item in _roomRepository.GetRoomByNumber(roomNumber).AdditEquipments)
                {
                    if (String.Compare(item.Name, "wifi", true) == 0)
                        ViewBag.Wifi = true;
                    if (String.Compare(item.Name, "projector", true) == 0)
                        ViewBag.Projector = true;
                    if (String.Compare(item.Name, "monitor", true) == 0)
                        ViewBag.Monitor = true;
                    if (String.Compare(item.Name, "microphone", true) == 0)
                        ViewBag.Microphone = true;
                }
                return View();
            }                
            else
            {
                return RedirectToAction("Index", "Home");
            }               
        }

        [HttpPost]
        public ActionResult RoomDayReservations(string roomNumber, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var reservations = _reservationRepository.GetRoomReservationsByDate(roomNumber, date);

            ViewBag.RoomNumber = roomNumber;
            ViewBag.Date = date;
            ViewBag.BeginHour = 9;
            ViewBag.EndHour = 21;

            return PartialView(reservations);
        }

        public ActionResult RoomWeekReservations(string roomNumber, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var reservations = _reservationRepository.GetRoomWeekReservationsByDate(roomNumber, date);

            ViewBag.RoomNumber = roomNumber;
            ViewBag.Date = date;
            ViewBag.BeginHour = 9;
            ViewBag.EndHour = 21;

            return PartialView(reservations);
        }

        [HttpPost]
        public void AddReservation(string roomNumber, int year, int month, int day, int beginHour, string purpose)
        {
            DateTime beginTime = new DateTime(year, month, day).AddHours(beginHour);
            var room = _roomRepository.GetRoomByNumber(roomNumber);

            if (room != null)
            {
                _reservationRepository.AddReservation(User.Identity.GetUserId(), room.Id, beginTime, beginTime.AddHours(1), purpose);
            }           
        }

        [HttpPost]
        public void DelReservation(string roomNumber, int year, int month, int day, int beginHour)
        {
            DateTime beginTime = new DateTime(year, month, day).AddHours(beginHour);
            var room = _roomRepository.GetRoomByNumber(roomNumber);

            if(room != null)
            {
                if(User.IsInRole("admin"))
                {
                    _reservationRepository.DelReservationByAdmin(room.Id, beginTime);
                }
                else
                {
                    _reservationRepository.DelReservation(User.Identity.GetUserId(), room.Id, beginTime);
                }                
            }           
        }

        [HttpPost]
        public void AddBlock(string roomNumber, int year, int month, int day, int beginHour)
        {
            DateTime beginTime = new DateTime(year, month, day).AddHours(beginHour);
            var room = _roomRepository.GetRoomByNumber(roomNumber);

            if (room != null)
            {
                _reservationRepository.AddBlock(User.Identity.GetUserId(), room.Id, beginTime, beginTime.AddHours(1));
            }
        }
    }
}