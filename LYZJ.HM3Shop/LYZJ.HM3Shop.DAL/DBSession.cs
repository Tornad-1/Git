using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using System.Data.Common;


namespace LYZJ.HM3Shop.DAL
{   //DbSession实现了单元工作模式 UnitWork,把一系列对数据库的操作封装成一个单元，一次性的把单元工作里面的所有改变都提交到数据库里面去
    public class DbSession:IDbSession
    {//封装了SaveChanges()方法，保证在一个业务场景中操作多个表只需要一次的提交，减少了跟数据库交互的次数。
        public IDAL.IRoleRepository RoleRepository
        {
            get { return new RoleRepostory(); }
        }
        public IDAL.IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }
        //将数据访问层的SaveChanges()方法提到业务逻辑层(数据访问层不在控制SaveChanges方法），以便于DbSession一次性提交所有操作
        //封装了一个SaveChanges方法，该方法直接去获取当前线程里面的上下文，然后调用上下文的SaveChanges方法，就相当于直接把当前线程内部所有实体的改变提交到数据库里面
        public int SaveChanges()
        {
            //调用EF上下文的SaveChanges方法
            return DAL.EFContextFactory.GetCurrentDbContext().SaveChanges();
        }
        /// <summary>
        /// 执行sql脚本
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        public int ExcuteSql(string strSql,DbParameter[] Parameter)
        {
            //封装一个执行SQl脚本的代码
            //return DAL.EFContextFactory.GetCurrentDbContext().ExecuteFunction(strSql, parameters);

             throw new NotImplementedException();
        }
    }
}
