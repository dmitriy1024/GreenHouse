using System.Web.Mvc;
using GreenHouse.Domain.Abstract;
using System;

namespace GreenHouse.WebUI.Controllers
{
    public class HomeUserController : Controller
    {
        private IRoomRepository _repository;

        public HomeUserController(IRoomRepository productRepository)
        {
            _repository = productRepository;
        }

        public ActionResult Index()
        {
            var rooms = _repository.GetRoomsByDate(new DateTime(2015,9,8));
            return View(rooms);
        }
    }
}