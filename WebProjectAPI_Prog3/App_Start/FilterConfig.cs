using System.Web;
using System.Web.Mvc;

namespace WebProjectAPI_Prog3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
