using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class ResultFilterController : Controller
    {
        // GET: ResultFilter
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 10)]
        public ActionResult GetCacheTtime()
        {
            ViewBag.Time = DateTime.Now;
            Thread.Sleep(2000);
            return View();
        }
    }
}