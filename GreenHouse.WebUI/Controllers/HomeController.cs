using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouse.Domain.Concrete;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Entities;
using GreenHouse.WebUI.Models;

namespace GreenHouse.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IReservationRepository _reservationRepository;

        public HomeController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        //public ActionResult Index()
        //{
        //    var res = _reservationRepository.GetReservationsByDate(new DateTime(2015, 09, 15));
        //    foreach (var item in res)
        //    {
        //        System.Diagnostics.Debug.WriteLine(item.AspNetUser.Email);
        //    }
        //    return View();
        //}

        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Reservations(int year, int month, int day)
        {
            Reservation[,] resArr = new Reservation[15, 8];

            var res = _reservationRepository.GetReservationsByDate(new DateTime(year, month, day));
            foreach (var item in res)
            {
                int roomNum = Int32.Parse(item.Room.Number);
                int timeRes = ((DateTime)item.EndTime).Hour - 7;
                resArr[roomNum - 300, timeRes] = item;
            }

            return PartialView(resArr);
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