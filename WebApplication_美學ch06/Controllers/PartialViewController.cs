using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class PartialViewController : Controller
    {
        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }

        //2秒後輸出現在時間，利用PartialView
        public ActionResult GetTime()
        {
            Thread.Sleep(2000);
            return PartialView("_GetTimePartial");
        }

        public ActionResult DemoPartialView()
        {
            return View();
        }
    }
}