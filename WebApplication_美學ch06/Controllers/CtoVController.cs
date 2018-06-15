using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication_美學ch06.Models;
using WebApplication_美學ch06.Models.ViewModel;

namespace WebApplication_美學ch06.Controllers
{
    public class CtoVController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

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

        public ActionResult DemoTempData()
        {
            ViewData["Msg1"] = "From ViewData Message";
            ViewBag.Msg2 = "From ViewBag Message.";
            TempData["Msg3"] = "From TempData Message.";
            return RedirectToAction("Redirect1");
        }

        public ActionResult Redirect1()
        {
            //取出處理
            TempData["Msg4"] = TempData["Msg3"];
            return RedirectToAction("GetRedirectData");
        }

        public ActionResult GetRedirectData()
        {
            return View();
        }

        public ActionResult DemoTempDataProduct()
        {
            TempData["products"] = db.Products.ToList();
            return Redirect("DemoTempDataKeep");
        }

        public ActionResult DemoTempDataKeep()
        {
            return View();
        }

        public ActionResult DemoInclude()
        {
            var products = db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult DemoSelectList()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID","CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        public ActionResult DemoMultiModelObject()
        {
            ViewBag.Author = "Bruce";
            ViewBag.Book = "ASP.NET MVC 5 ";
            ViewBag.Product = (from p in db.Products select p).Take(10).ToList();
            ViewBag.Category = (from c in db.Categories select c).Take(10).ToList();
            return View();
        }

        public ActionResult DemoViewMdoel()
        {
            return View(new ProductCategoryViewModel()
            {
                Name = "Bruce",
                Book = "ASP.NET MVC 5",
                Product = (from p in db.Products select p).Take(10).ToList(),
                Category = (from c in db.Categories select c).Take(10).ToList()
            });
        }

        public ActionResult DemoTuple()
        {
            var products = db.Products.ToList();
            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();
            var tupleModel = new Tuple<List<Product>, List<Category>, List<Supplier>>(products, categories, suppliers);

            return View(tupleModel);
        }
    }
}