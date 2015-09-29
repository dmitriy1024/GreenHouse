using GreenHouse.Domain.Entities;
using GreenHouse.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenHouse.WebUI.Infrastructure
{
    static public class AspNetUserExtentions
    {
        public static bool IsAdmin(this AspNetUser user)
        {
<<<<<<< HEAD
            var i = 9;
=======
>>>>>>> 2a6f835f6074e3c27c6043e47c9f456b2de536f0
            using (var context = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                return userManager.IsInRole(user.Id, "admin");
            }
        }
    }
}