using CyberResilience.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.Controllers.Services
{
    [Authorize(Roles = "RegisteredUser, Employee, Admin")]
    public class PlatformController : BaseController
    {
        // GET: Platform
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        public ActionResult Index()
        {




            return View();
        }








    }
}