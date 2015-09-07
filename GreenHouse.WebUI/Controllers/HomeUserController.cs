using System.Web.Mvc;
using GreenHouse.Domain.Abstract;

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
            return View(_repository.Rooms);
        }
    }
}