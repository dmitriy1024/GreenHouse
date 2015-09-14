using System.Web.Mvc;
using GreenHouse.Domain.Abstract;
using System;
using GreenHouse.Domain.Entities;

namespace GreenHouse.WebUI.Controllers
{

    public class HomeController : Controller
    {
        private IRoomRepository _repository;

        public HomeController(IRoomRepository productRepository)
        {
            _repository = productRepository;
        }

        public ActionResult Index()
        {

            Reservation[,] resArr = new Reservation[15,8];

            var res = _repository.GetReservationsByDate(new DateTime(2015, 9, 8));
            foreach (var item in res)
            {
                int roomNum = Int32.Parse(item.Room.Number);
                int timeRes = ((DateTime)item.EndTime).Hour - 7;
                resArr[roomNum - 300, timeRes] = item;
            }
            return View(resArr);
        }

        [HttpPost]
        public ActionResult Reservations(int year = 5, int month = 5, int day = 5)
        {
            Reservation[,] resArr = new Reservation[15, 8];

            var res = _repository.GetReservationsByDate(new DateTime(2015, 9, 8));
            foreach (var item in res)
            {
                int roomNum = Int32.Parse(item.Room.Number);
                int timeRes = ((DateTime)item.EndTime).Hour - 7;
                resArr[roomNum - 300, timeRes] = item;
            }

            return PartialView(resArr);
        }
    }

}