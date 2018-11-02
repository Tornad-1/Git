using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYZJ.HM3Shop.Common;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.BLL;
using LYZJ.HM3Shop.IBLL;
using LYZJ.HM3Shop.Model;

namespace LYZJ.HM3Shop.Controllers
{
    public class LoginController : Controller
    {
        private IUserInfoService _iUserInfoService = new UserInfoService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 验证码的校验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        /// <summary>
        /// 处理登录的信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public ActionResult CheckUserLogin(UserInfo userInfo, string Code)
        {
            //如果有用户名的话讲用户名存放到Cookie中
            if (userInfo.UName != null)
            {
                Response.Cookies["UName"].Value = userInfo.UName;
                Response.Cookies["UName"].Expires = DateTime.Now.AddDays(7);
            }


            //这里验证用户输入的验证码和系统的验证码是否相同
            string sessionCode = Session["ValidateCode"] == null ? new Guid().ToString() : Session["ValidateCode"].ToString();

            //将验证码去掉，避免暴力破解
            Session["ValidateCode"] = new Guid();//TempData[]为空  所有使用session来取出数据

            if (sessionCode != Code)
            {
                return Content("请输入正确的验证码");
            }

            //调用BLL检验用户名密码是否正确
            string UserInfoError = "";
            var LoginUserInfo = _iUserInfoService.CheckUserInfo(userInfo);
            switch (LoginUserInfo)
            {
                case LoginResult.PwdError:
                    UserInfoError = "输入密码错误";
                    break;
                case LoginResult.UserNotExist:
                    UserInfoError = "用户名输入错误";
                    break;
                case LoginResult.UserIsNull:
                    UserInfoError = "用户名不能为空";
                    break;
                case LoginResult.OK:
                    UserInfoError = "OK";
                    break;
                default:
                    UserInfoError = "未知错误,请检查您的数据库";
                    break;
            }
            return Content(UserInfoError);
        }
    }
}