using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using LYZJ.HM3Shop.Model;

namespace LYZJ.HM3Shop.DAL
{
    public class EFContextFactory
    {   
        //帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证上线问实例在线程内部是唯一的
        public static DbContext GetCurrentDbContext()
        {   //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
            DbContext dbcontext = CallContext.GetData("DbContext") as DbContext;//在当前线程中检索名为DbContext的上下文
            if (dbcontext == null)//如果不存在此上下文
            {
                dbcontext = new LYZJDbContext();
                CallContext.SetData("DbContext", dbcontext);//创建并存入数据槽
            }
            return dbcontext;
        }
    }
}
