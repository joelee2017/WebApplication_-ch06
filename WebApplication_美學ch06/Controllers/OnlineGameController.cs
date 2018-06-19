using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class OnlineGameController : Controller
    {
        // GET: OnlineGame
        public ActionResult OnlineGame()
        {
            return View();
        }

        public ActionResult NextTime()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"var nextTime='{DateTime.UtcNow}';\r\n" );
            return JavaScript(sb.ToString());
        }
    }
}