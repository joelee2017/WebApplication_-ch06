using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Filters;

namespace WebApplication_美學ch06.Controllers
{
    [Mvc5Authv2]
    public class AdminController : Controller
    {
        // GET: Admin
        [Mvc5Authv1]
        public ActionResult Index()
        {
            return Content("Mvc5Authv1 can see");
        }
    }
}