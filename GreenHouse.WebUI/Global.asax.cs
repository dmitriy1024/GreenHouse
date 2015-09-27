using GreenHouse.WebUI.Infrastructure;
using GreenHouse.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenHouse.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            using (var context = new ApplicationDbContext())
            {
                if (context.Roles.Where(a => String.Compare(a.Name, "admin", true) == 0).Count() == 0)
                {
                    context.Roles.Add(new IdentityRole("admin"));
                    context.SaveChanges();
                }            
                
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser() { UserName = "Admin", Email = "admin@gmail.com" };
                var createResult = um.Create(user, "Aa123!");
                if(createResult.Succeeded)
                {
                    var roleresult = um.AddToRole(user.Id, "admin");
                }                                                
            }
        }
    }
}
