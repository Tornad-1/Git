using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Common;

namespace LYZJ.HM3Shop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

    }
}