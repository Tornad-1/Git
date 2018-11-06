using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LYZJ.HM3Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["Count"] = 0;//在应用程序第一次启动时初始化在线人数为0
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Count"] = Convert.ToInt32(Application["Count"]) + 1;
            Application.UnLock();
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Count"] = Convert.ToInt32(Application["Count"]) - 1;
            Application.UnLock();
        }

    }
}
