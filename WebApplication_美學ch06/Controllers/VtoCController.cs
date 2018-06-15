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

        //QueryString
        public ActionResult DemoQueryString()
        {
            ViewBag.id = int.Parse(Request.QueryString["id"]);
            return View();
        }

        //RouteData  {Controller}/{Action}/{Id}
        public ActionResult DemoRouteData(int id)
        {
            ViewBag.id = id;
            return View();
        }

        //簡單 Model Binding
        public ActionResult BasicModelBinding(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public ActionResult BasicModelBindingByModel(string name)
        {
            ViewData.Model = name;
            return View();
        }

        //FormCollection
        public ActionResult DemoFormCollection(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            return View();
        }

        //複雜 ModelBinding
        public ActionResult PersonModelBinding(Person person)
        {
            return View(person);
        }
    }
}