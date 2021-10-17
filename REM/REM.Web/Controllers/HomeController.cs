﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REM.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}