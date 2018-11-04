using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.Common;

namespace LYZJ.HM3Shop.IBLL
{
    public interface IUserInfoService:IBaseService<UserInfo>
    {/// <summary>
    /// 检查用户信息
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
      LoginResult CheckUserInfo(UserInfo userInfo);
      //int DeleteUserInfo(List<int> DeleteUserInfoID);
      /// <summary>
      /// 加载查询数据
      /// </summary>
      /// <param name="query"></param>
      /// <returns></returns>
      IQueryable<UserInfo> LoadSearchData(GetModelQuery query);
        /// <summary>
        ///  删除用户
        /// </summary>
        /// <param name="DeleteUserInfoID"></param>
        /// <returns></returns>
      int DeleteUserInfo(List<int> DeleteUserInfoID);
    }
}
