using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //დამატებული mxolod Https-istvis
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
