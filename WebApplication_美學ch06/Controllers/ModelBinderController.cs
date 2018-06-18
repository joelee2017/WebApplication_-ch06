using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class ModelBinderController : Controller
    {
        // GET: ModelBinder
        public ActionResult Index()
        {
            return View();
        }

        //ModelBinder 擴充 decimal 型別
        public ActionResult Test(decimal amount)
        {
            return View(amount);
        }
    }
}