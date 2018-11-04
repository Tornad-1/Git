using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Models;

namespace LYZJ.HM3Shop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new IsAuthorizeAttribute());
        }
    }
}
