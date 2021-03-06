﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Filters;

namespace WebApplication_美學ch06.Controllers
{
    [OutputCache(CacheProfile ="HomeCache")]
    public class HomeController : Controller
    {
        [Mvc5Authv2]
        public ActionResult Index()
        {
            return View();
        }

        //[ChildActionOnly]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}