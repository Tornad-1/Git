using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using LYZJ.HM3Shop.IDAL;

namespace LYZJ.HM3Shop.DAL
{
    public class DbSessionFactory
    {//确保当前线程内DbSession实例的唯一
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession _dbSession = CallContext.GetData("DbSession") as IDbSession;
            if (_dbSession == null)
            {
                _dbSession = new DbSession();
                //将值存入数据槽
                CallContext.SetData("DbSession", _dbSession);
            }
            return _dbSession;
        }
    }
}
