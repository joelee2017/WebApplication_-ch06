using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;
using WebApplication_美學ch06.Models.ViewModel;

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

        //多 Model 的 Model Binding
        public ActionResult MultiPersonModelBinding(Person man, Person woman)
        {
            ViewBag.ManName = man.Name;
            ViewBag.ManAge = man.Age;

            ViewBag.WomanName = woman.Name;
            ViewBag.WomanAge = woman.Age;

            return View();
        }

        //PersonViewModel
        public ActionResult ViewModelModelBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewModelModelBinding(PersonViewModel person )
        {
            //ViewModelModelBinding  Submit 資收接到轉到 ShowViewModelModelBinding 頁面
            return View("ShowViewModelModelBinding", person);
        }



    }
}