using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouse.Domain.Abstract;

namespace GreenHouse.WebUI.Controllers
{
    public class DailyController : Controller
    {
        private IRoomRepository _roomRepository;

        public DailyController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost]
        public JsonResult BookRoom(string date, string content)
        {
            return Json(new { date = date, content = content });
        }

        [HttpGet]
        public JsonResult GetRooms()
        {
            var rooms = _roomRepository.Rooms;

            var model = new List<object>();

            foreach (var room in rooms)
            {
                int bg = 0;
                if (room.Capacity < 30) bg = 30;
                if (room.Capacity >= 30 && room.Capacity < 70) bg = 70;
                if (room.Capacity >= 70 && room.Capacity < 100) bg = 100;
                if(room.Capacity >= 100) bg = 200;
                model.Add(new {
                    number = room.Number,
                    places = room.Capacity,
                    wifi = _roomRepository.AdditEquipmExists(room.Number, "wifi"),
                    projector = _roomRepository.AdditEquipmExists(room.Number, "projector"),
                    monitor = _roomRepository.AdditEquipmExists(room.Number, "monitor"),
                    microphone = _roomRepository.AdditEquipmExists(room.Number, "microphone"),
                    background = bg
                });
            }
            
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}