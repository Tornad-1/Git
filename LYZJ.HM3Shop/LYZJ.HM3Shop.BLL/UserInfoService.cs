using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.IBLL;

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
