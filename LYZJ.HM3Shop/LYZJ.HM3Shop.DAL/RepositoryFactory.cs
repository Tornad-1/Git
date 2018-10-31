using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;

namespace LYZJ.HM3Shop.DAL
{
    public class RepositoryFactory
    {//角色工厂，降低程序耦合
        public static IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }
        public static IRoleRepository RoleRepository
        {
            get { return new RoleRepostory(); }
        }
    }
}
