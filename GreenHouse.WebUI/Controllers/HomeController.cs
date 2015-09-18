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
            int rowCount = 12;
            int roomsCount = 15;
            int beginTime = 9;

            Reservation[,] resArr = new Reservation[roomsCount, rowCount];

            var res = _reservationRepository.GetReservationsByDate(new DateTime(year, month, day));

            foreach (var item in res)
            {
                int roomNum = Int32.Parse(item.Room.Number);
                int timeRes = (item.BeginTime).Hour - beginTime;
                resArr[roomNum - 301, timeRes] = item;
            }

            return PartialView(resArr);
        }

        [HttpPost]
        public void AddReservation(string roomAndTime, string currentDate, string purpose)
        {
            int begHour = Int32.Parse(roomAndTime.Split('-')[0]) + 9;
            int roomNumber = Int32.Parse(roomAndTime.Split('-')[1]) + 301;
            var res = (currentDate.Split(' '));
            int year = Int32.Parse(currentDate.Split(' ')[6]);
            int month = Int32.Parse(currentDate.Split(' ')[4]);
            int day = Int32.Parse(currentDate.Split(' ')[2]);

            DateTime beginTime = new DateTime(year, month, day).AddHours(begHour);

            _reservationRepository.AddReservation(User.Identity.GetUserId(), roomNumber.ToString(), beginTime, beginTime.AddHours(1), purpose);
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