﻿using CyberResilience.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToolkitController : BaseController
    {
        // GET: Toolkit
        public ActionResult Index()
        {
            return View();
        }
    }
}