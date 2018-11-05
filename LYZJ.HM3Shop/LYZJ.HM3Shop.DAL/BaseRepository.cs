using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LYZJ.HM3Shop.DAL
{/// <summary>
 /// 仓储基类，实现了增删改查
 /// </summary>
 /// <typeparam name="T">泛型类，实例化时传入实际类型</typeparam>
    public class BaseRepository<T> where T : class
    {//将上下文放到Dbsession中去管理
        private DbContext db = EFContextFactory.GetCurrentDbContext();// 使用工厂返回当前数据上下文
        public T AddEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;//添加实体（实体被上下文追踪但是现在还不存在于数据库中）
            //db.SaveChanges();将SaveChanges()放在BLL层中调用
            return entity;
        }
        public Boolean RemoveHoldingEntityInContext(T entity)
        {
            var objContext = ((IObjectContextAdapter)db).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }
        public bool UpdateEntity(T entity)
        {
            RemoveHoldingEntityInContext(entity);
            db.Set<T>().Attach(entity);//附加实体（ 区别于Added）
            db.Entry<T>(entity).State = EntityState.Modified;
            //return db.SaveChanges() > 0;
            db.SaveChanges();
            return true;
        }      
        public bool DeleteEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            //return db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 加载数据        IQueryable<T>  linq to sql 生成sql脚本进行查询    Func<T, bool>会进行查询全表
        /// </summary> 
        /// <param name="whereLambda">加载的条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda).AsQueryable().AsNoTracking();//将 IEnumerable 或泛型 IEnumerable<T> 转换为 IQueryable 或泛型 IQueryable<T>。   在使用LINQ进行数据集操作时，LINQ 不能直接从数据集对象中查询，因为数据集对象不支持LINQ 查询，所以需要使用AsQueryable 方法返回一个泛型的对象以支持LINQ 的查询操作。
        }
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">如何排序，根据倒叙还是升序</param>
        /// <param name="orderByLambda">根据哪个字段进行排序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool>
            whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count();//获取当前的页数
            // 排序
            if (isAsc)
            {//跳过指定页数*指定页数数据的数据，获取指定页数数据并按指定页数进行排序
                temp = temp.OrderBy<T, S>(orderByLambda).Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize).AsQueryable();
            }
            return temp.AsQueryable();
        }
    }
}
