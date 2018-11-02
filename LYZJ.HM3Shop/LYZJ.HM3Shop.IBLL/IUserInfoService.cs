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
    {
      LoginResult CheckUserInfo(UserInfo userInfo);
    }
}
