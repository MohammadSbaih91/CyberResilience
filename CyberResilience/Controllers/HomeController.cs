using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CyberResilience.Controllers
{
    [AllowAnonymous]
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class HomeController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}