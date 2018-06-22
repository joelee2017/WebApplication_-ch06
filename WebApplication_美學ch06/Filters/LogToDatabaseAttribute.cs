using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Filters
{
    public class LogToDatabaseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          // 已登入用戶端
          if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                NorthwindEntities db = new NorthwindEntities();
                ActionLog log = new ActionLog()
                {
                    UserName = filterContext.HttpContext.User.Identity.Name,
                    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    ActionName = filterContext.ActionDescriptor.ActionName,
                    IPAddress = filterContext.HttpContext.Request.UserHostAddress,
                    CreatedDate = filterContext.HttpContext.Timestamp,
                };
                db.ActionLogs.Add(log);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}