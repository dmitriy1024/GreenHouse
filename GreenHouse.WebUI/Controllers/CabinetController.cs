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

        public CabinetController(IAspUserRepository aspUserRepository)
        {
            _aspUserRepository = aspUserRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.User = _aspUserRepository.GetAspNetUserById(User.Identity.GetUserId());
            return View();
        }
        
    }
}