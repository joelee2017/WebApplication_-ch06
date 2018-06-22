using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Filters;

namespace WebApplication_美學ch06
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogOutputAttribute());
            filters.Add(new LogToFileAttribute());
        }
    }
}
