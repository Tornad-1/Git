using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.IBLL;
using LYZJ.HM3Shop.BLL;

namespace LYZJ.HM3Shop.Controllers
{
    public class UserInfoController : Controller
    {
        private LYZJDbContext db = new LYZJDbContext();
        private IBLL.IUserInfoService _userInfoService = new UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllUserInfos()
        {
            //return Json(db.UserInfo.ToList());
            //Json格式的要求{total:22,rows:{}}

            //实现对用户分页的查询，rows：一共多少条，page：请求的当前第几页

            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);

            int total = 0;

            //调用分页的方法，传递参数,拿到分页之后的数据

            var data = _userInfoService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.UserInfoID);

            //构造成Json的格式传递

            var result = new { total = total, rows = data };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}