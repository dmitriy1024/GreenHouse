using System.Collections.Generic;
using System.Web.Mvc;
using GreenHouse.Domain.Entities;
using GreenHouse.Domain.Concrete;

namespace GreenHouse.WebUI.Controllers
{
    public class HomeUserController : Controller
    {
        // GET: HomeUser
        public ActionResult Index()
        {
            var v = new EFRoomRepository().Rooms;
            return View(v);
        }
    }
}