using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouse.Domain.Concrete;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using GreenHouse.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace GreenHouse.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IReservationRepository _reservationRepository;
        private IRoomRepository _roomRepository;

        public HomeController(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reservations(int year, int month, int day)
        {
            var roomsAndResByDate = _roomRepository.GetRoomsAndReservationsByDate(new DateTime(year, month, day));

            ViewBag.BeginHour = 9;
            ViewBag.EndHour = 21;
            return PartialView(roomsAndResByDate);
        }

        [HttpPost]
        public void AddReservation(int roomId, int year, int month, int day, int beginHour, string purpose)
        {   
            DateTime beginTime = new DateTime(year, month, day).AddHours(beginHour);

            _reservationRepository.AddReservation(User.Identity.GetUserId(), roomId, beginTime, beginTime.AddHours(1), purpose);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}