using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Model;
 

namespace LYZJ.HM3Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LYZJDbContext db = new LYZJDbContext();            
            return View(db.UserInfo.ToList());
        }

    }
}