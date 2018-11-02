using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYZJ.HM3Shop.Common
{   
    /// <summary>
    ///  枚举用户登录时出现的各种情况
    /// </summary>
    public enum LoginResult
    {
        PwdError,

        UserNotExist,

        UserIsNull,

        PwdIsNull,

        OK,
    }
}
