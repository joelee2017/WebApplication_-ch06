using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Controllers
{
    public class VtoCController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: VtoC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DemoQueryString()
        {
            ViewBag.id = int.Parse(Request.QueryString["id"]);
            return View();
        }

        public ActionResult DemoRouteData(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}