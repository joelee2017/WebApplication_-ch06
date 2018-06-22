using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class ExceptionFilterController : Controller
    {
        // GET: ExceptionFilter
        //[HandleError(View = "Error", ExceptionType = typeof(Exception))]
        public ActionResult Index()
        {
            throw new Exception("測試 Error 頁面。");
            return View();
        }

        
    }
}