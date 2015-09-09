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
            //Reserve reservedRoom1 = new Reserve(1, 2, "Oleg Zubenko");
            //Reserve reservedRoom2 = new Reserve(5, 6, "Andrew Zagoruy");
            //Reserve reservedRoom3 = new Reserve(3, 5, "Andrew Popov");

            //Reserve[,] resArr = new Reserve[15, 8];

            //resArr[1, 2] = reservedRoom1;
            //resArr[5, 6] = reservedRoom2;
            //resArr[3, 5] = reservedRoom3;

            Reservation[,] resArr = new Reservation[15,8];

            var res = _repository.GetReservationsByDate(new DateTime(2015, 9, 8));
            foreach (var item in res)
            {
                int roomNum = Int32.Parse(item.Room.Number);
                int timeRes = ((DateTime)item.EndTime).Hour;
                resArr[roomNum - 300, timeRes] = item;
            }
            return View(resArr);
        }

    }

    public class Reserve
    {
        public int RoomNum { get; private set; }
        public int Time { get; private set; }
        public string Name { get; private set; }

        public Reserve(int room, int time, string name)
        {
            RoomNum = room;
            Time = time;
            Name = name;
        }
    }

}