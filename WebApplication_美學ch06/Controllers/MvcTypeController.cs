using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Controllers
{
    public class MvcTypeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: MvcType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoJson1()
        {
            Person person = new Person
            {
                Name = "Bruce",
                Age = 18
            };
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DemoJson2()
        {
            var person = new
            {
                Name = "Bruce",
                Age = 18,
                Birthday = new DateTime(2099, 9, 9)
            };
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DemoJsonModel(int? id)
        {
            //LazyLoadingEnabled 處理循環參考 延遲加載已啟用
            db.Configuration.LazyLoadingEnabled = false;
            Product product = db.Products.Find(id);
            return Json(product);

        }

        [HttpPost]
        public ActionResult GetPersonJson(Person[] p)
        {
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DemoRedirect(string param)
        {
            if(!string.IsNullOrEmpty(param))
            {
                string baseUrl = "http://localhost:6031/";
                Url url = new Url(baseUrl + param);
                return Redirect(url.ToString());
            }
            else
            {
                return Content("error");
            }
        }
    }
}