using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace LYZJ.HM3Shop.IDAL
{
    public interface IDbSession
    {   //每个表对应的实体仓储对象
        IDAL.IRoleRepository RoleRepository { get; }
        IDAL.IUserInfoRepository UserInfoRepository { get; }
        int SaveChanges();
        int ExcuteSql(string strSql,DbParameter[] Paramters); //执行Sql脚本
    }
}
