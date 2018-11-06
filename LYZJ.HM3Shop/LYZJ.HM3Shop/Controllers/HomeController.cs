using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Model;
 

namespace LYZJ.HM3Shop.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Count = Convert.ToInt32(HttpContext.Application["Count"]);
            UserInfo uInfo = Session["UserInfo"] as UserInfo;
            if (uInfo != null)
            {
                ViewBag.UName = uInfo.UName;
            }

            LYZJDbContext db = new LYZJDbContext();            
            return View(db.UserInfo.ToList());
        }

    }
}