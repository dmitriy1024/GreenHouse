using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse.WebUI.Controllers
{
    public class DailyController : Controller
    {
        [HttpPost]
        public JsonResult BookRoom(string date, string content)
        {
            return Json(new { date = date, content = content });
        }

        [HttpGet]
        public JsonResult GetRooms()
        {
            var model = new object[]
                        {
                            new
                            {
                                number = 301,
                                places = 35,
                                wifi = true,
                                projector = false,
                                monitor = true,
                                microphone = false
                            },
                            new
                            {
                                number = 302,
                                places = 100,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 303,
                                places = 80,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = false
                            },
                            new
                            {
                                number = 304,
                                places = 100,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 305,
                                places = 20,
                                wifi = true,
                                projector = false,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 306,
                                places = 60,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 307,
                                places = 20,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 308,
                                places = 50,
                                wifi = true,
                                projector = true,
                                monitor = false,
                                microphone = true
                            },
                            new
                            {
                                number = 309,
                                places = 80,
                                wifi = false,
                                projector = true,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 310,
                                places = 100,
                                wifi = false,
                                projector = false,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 311,
                                places = 15,
                                wifi = true,
                                projector = false,
                                monitor = true,
                                microphone = false
                            },
                            new
                            {
                                number = 312,
                                places = 75,
                                wifi = true,
                                projector = false,
                                monitor = true,
                                microphone = true
                            },
                            new
                            {
                                number = 313,
                                places = 150,
                                wifi = true,
                                projector = true,
                                monitor = true,
                                microphone = false
                            },
                            new
                            {
                                number = 314,
                                places = 70,
                                wifi = false,
                                projector = false,
                                monitor = false,
                                microphone = false
                            },
                            new
                            {
                                number = 315,
                                places = 27,
                                wifi = true,
                                projector = false,
                                monitor = true,
                                microphone = false
                            }
                        };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}