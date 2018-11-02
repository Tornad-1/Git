using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.IBLL;
using LYZJ.HM3Shop.Common;

namespace LYZJ.HM3Shop.BLL
{
    public class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        //private IUserInfoRepository _userInfoRepository = new UserInfoRepository();//实例化接口对象
        //private IUserInfoRepository _userInfoRepository = RepositoryFactory.UserInfoRepository;
        //调用数据访问层接口，封装增删改查方法
        //重写抽象方法，设置当前仓储为UserInfo仓储
        public override void SetCurrentReposity()
        {
            CurrentRepository = DAL.RepositoryFactory.UserInfoRepository;
        }
        public LoginResult CheckUserInfo(UserInfo userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.UName))
            {
                return LoginResult.UserIsNull;
            }
            if (string.IsNullOrEmpty(userInfo.Pwd))
            {
                return LoginResult.PwdIsNull;
            }

           var  LoginUserInfoInfoCheck= _DbSession.UserInfoRepository.LoadEntities(u => u.UName == userInfo.UName ).FirstOrDefault();//此处不能与上pwd，否则用户名错误和密码错误都会显示用户名错误（LoginUserInfoInfoCheck==null）/*&& e.Pwd == userInfo.Pwd*/
            if (LoginUserInfoInfoCheck == null)//当用户名密码不匹配时，为null Why？
            {
                return LoginResult.UserNotExist;
            }
            if (LoginUserInfoInfoCheck.Pwd != userInfo.Pwd)
            {
                return LoginResult.PwdError;
            }
            else
            {
                return LoginResult.OK;
            }
        }

        //public UserInfo AddUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.AddEntity(userInfo);
        //}
        //public bool UpdateUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.UpdateEntity(userInfo);
        //}
        //public bool DeleteUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.DeleteEntity(userInfo);
        //}
    }
}
