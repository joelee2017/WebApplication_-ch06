﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Filters
{
    public class LogToFileAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(DateTime.Now.ToString());
            // Todo: 以下組織要記錄的內容
            message.AppendLine(filterContext.Exception.ToString());
            message.AppendLine("==========================================");
            string filePath = "~/App_Data/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath(filePath), message.ToString());
        }
    }
}