using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.Common;
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

        /// <summary>
        /// 加载用户模糊查询的数据（调用LoadEntities实现加载）
        /// </summary>
        /// <param name="query">进行模糊查询的参数的类型</param>
        /// <returns></returns>
        public IQueryable<UserInfo> LoadSearchData(GetModelQuery query)
        {
            //拿到所有的数据
            var temp = _DbSession.UserInfoRepository.LoadEntities(u => true);

            //进行过滤姓名
            if (!string.IsNullOrEmpty(query.Name))
            {
                temp = temp.Where<UserInfo>(u => u.UName.Contains(query.Name));
            }
            //进行邮箱的过滤
            if (!string.IsNullOrEmpty(query.Mail))
            {
                temp = temp.Where<UserInfo>(u => u.Mail.Contains(query.Mail));
            }
            //进行回收站过滤
            if (query.DelFlag==0)
            {
                temp = temp.Where<UserInfo>(u => u.DelFlag==0);
            }
            if (query.DelFlag == 1)
            {
                temp = temp.Where<UserInfo>(u => u.DelFlag == 1);
            }
            //返回总数
            query.total = temp.Count();

            //做分页查询
            return temp.Skip(query.pageSize * (query.pageIndex - 1)).Take(query.pageSize).AsQueryable();

        }
        /// <summary>
        /// 删除用户（调用接口函数DeleteEntity()实现删除）
        /// </summary>
        /// <param name="DeleteUserInfoID"></param>
        /// <returns></returns>
        public int DeleteUserInfo(List<int> DeleteUserInfoID)
        {
            foreach (var ID in DeleteUserInfoID)
            {
                _DbSession.UserInfoRepository.DeleteEntity(new UserInfo() { UserInfoID = ID });
            }
            return _DbSession.SaveChanges();
        }

    }
}
