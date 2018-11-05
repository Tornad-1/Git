using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.IBLL;
using LYZJ.HM3Shop.BLL;
using LYZJ.HM3Shop.Common;
using LYZJ.HM3Shop.Model.Enum;
using System.Collections;
using LYZJ.HM3Shop.DAL;


namespace LYZJ.HM3Shop.Controllers
{
    public class UserInfoController : BaseController
    {

        private IBLL.IUserInfoService _userInfoService = new UserInfoService();

        private IDAL.IUserInfoRepository _userInfoRepository = new UserInfoRepository();

        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 得到用户的所有信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUserInfos()
        {
            //json数据：{total:"",row:""}
            //
            //分页的数据
            //

            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);//判断查询的页数
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);//判断查询的页数


            ////SearchName,SearchMail
            string searchName = Request["SearchName"];//模糊查询的关键字
            string searchMail = Request["SearchMail"];//模糊查询的关键字

            //封装一个业务逻辑层，来处理分页过滤的事件
            GetModelQuery userInfoQuery = new GetModelQuery();
            userInfoQuery.pageIndex = pageIndex;
            userInfoQuery.pageSize = pageSize;
            userInfoQuery.Name = searchName;
            userInfoQuery.Mail = searchMail;
            userInfoQuery.total = 0;

            //放置依赖刷新
            var data = from u in _userInfoService.LoadSearchData(userInfoQuery)
                       select new { u.UserInfoID, u.UName, u.Phone, u.Pwd, u.Mail, u.LastModifiedOn, u.SubTime };//将查询到的数据投影到新表单

            //var data = _userInfoService.LoadPageEntities(pageSize, pageIndex, out total, u => true, true, u => u.UserInfoID);

            var result = new { total = userInfoQuery.total, rows = data };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public ActionResult Regist(UserInfo userinfo)
        {
            //给表中的默认字段赋值
            userinfo.LastModifiedOn = DateTime.Now;// 最近一次修改时间
            userinfo.SubTime = DateTime.Now;//提交时间
            //在这里需要用到枚举类型，不要写0
            userinfo.DelFlag = (short)DelFlagEnum.Normal;//设置状态Normal

            _userInfoService.AddEntity(userinfo);
            return Content("OK");

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="deleteUserInfoID"></param>
        /// <returns></returns>
        public ActionResult DeleteUserInfo(string deleteUserInfoID, string UName)
        {
            //========================================== Application 待完成 =======================================
            //首先确认是哪个用户登录进来的，如果此用户正在登录系统，则不允许删除此用户
            //string a = Convert.ToString(HttpContext.Application["User"]);//获取Application对象中的User变量
            //int len = a.Length;
            //a = a.Substring(0, len - 1);
            //var arr = a.Split(',');//分隔sessionID
            //List<string> sessionID = new List<string>();
            //foreach (var ID in arr)
            //{
            //    sessionID.Add(ID);
            //}
            //=========================================== Application 待完成 ========================================
            UserInfo UInfo = Session["UserInfo"] as UserInfo;
            var LoginUName = UInfo.UName;//tz
            var UIdsName = UName.Split(',');//hyl
            List<string> deleteUName = new List<string>();
            foreach (var Name in UIdsName)
            {
                deleteUName.Add(Name);
            }
            if (deleteUName.Contains(LoginUName))
            {
                return Content("含有正在使用的用户，禁止删除");
            }

            if (string.IsNullOrEmpty(deleteUserInfoID))
            {
                return Content("请选择您要删除的数据");
            }
            //截取传递过来的字符串的数字信息
            var idsStr = deleteUserInfoID.Split(',');

            List<int> deleteIDList = new List<int>();

            foreach (var ID in idsStr)
            {
                deleteIDList.Add(Convert.ToInt32(ID));
            }
            if (_userInfoService.DeleteUserInfo(deleteIDList) > 0)
            {
                return Content("OK");
            }
            return Content("删除失败，请您检查");


            #region -----实现只删除一条数据--------
            //_userInfoService.DeleteUser(deleteIDList);
            //实例化UserInfo表
            //UserInfo userInfo = new UserInfo();
            //userInfo.ID = deleteUserInfoID;
            //_userInfoService.DeleteEntities(userInfo);
            #endregion

        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult UpdateInfo(UserInfo userInfo)
        {
            //首先查询出要修改的实体对象
            var EditUserInfo = _userInfoRepository.LoadEntities(c => c.UserInfoID == userInfo.UserInfoID).FirstOrDefault();// UserInfoID:3

            //查询出实体对象给重新复制
            EditUserInfo.UName = userInfo.UName;
            EditUserInfo.Pwd = userInfo.Pwd;
            EditUserInfo.Mail = userInfo.Mail;
            EditUserInfo.Phone = userInfo.Phone;
            EditUserInfo.DelFlag = 0;

            _userInfoRepository.UpdateEntity(userInfo);

            return Content("OK");
        }

        /// <summary>
        /// 检查用户名是否已经存在
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult CheckUserName(UserInfo userInfo)
        {
            var UName = _userInfoService.LoadEntities(u => u.UName == userInfo.UName).FirstOrDefault();
            if (UName != null)
            {
                return Content("OK");
            }
            else
            {
                return Content("Error");
            }
        }
        /// <summary>
        /// 绑定用户数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult GetBindDetails(int ID)
        {
            var BindIDForUpdateTextBox = _userInfoService.LoadEntities(u => u.UserInfoID == ID).FirstOrDefault();

            //JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();
            //var Details = JavaScriptSerializer.Serialize(BindIDForUpdateTextBox);
            //return Content(Details);
            return Json(BindIDForUpdateTextBox, JsonRequestBehavior.AllowGet);
        }

    }
}