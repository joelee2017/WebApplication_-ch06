using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class CtoVController : Controller
    {
        // GET: CtoV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoInput()
        {
            return View();
        }

        public ActionResult CheckInput(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "不得空白!";
                return RedirectToAction("DemoInput");
            }

            ViewBag.Name = name;
            return View();
        }
    }
}