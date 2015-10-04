using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenHouse.Domain.Abstract;
using Microsoft.AspNet.Identity;

namespace GreenHouse.WebUI.Controllers
{
    public class CabinetController : Controller
    {
        private IAspUserRepository _aspUserRepository;
        private IRoomRepository _roomRepository;

        public CabinetController(IAspUserRepository aspUserRepository, IRoomRepository roomRepository)
        {
            _aspUserRepository = aspUserRepository;
            _roomRepository = roomRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.User = _aspUserRepository.GetAspNetUserById(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        public JsonResult AddNewRoom(int selectedRoom, string capacity, string wifiOpt, string projectorOpt, string monitorOpt, string microphoneOpt)
        {
            _roomRepository.AddRoom(selectedRoom, capacity, wifiOpt, projectorOpt, monitorOpt, microphoneOpt);
            return Json("OK!");
        }

        [HttpPost]
        public JsonResult RemoveRoom(int selectedRoomR)
        {
            _roomRepository.RemoveRoom(selectedRoomR);
            return Json("OK!");
        }
    }
}