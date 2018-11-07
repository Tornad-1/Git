using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LYZJ.HM3Shop.Controllers
{    //通过基类控制器实现过滤（子控制器只需要继承便可过滤）
    public class BaseController : Controller
    {
        public UserInfo CurrentUserInfo { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            CurrentUserInfo = Session["UserInfo"] as UserInfo;
            if (CurrentUserInfo == null)
            {
                Response.Redirect("Login/Index");
            }
        }
        public ContentResult JsonDate(object Date)

        {

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

            return Content(JsonConvert.SerializeObject(Date, Formatting.Indented, timeConverter));

        }
    }
}