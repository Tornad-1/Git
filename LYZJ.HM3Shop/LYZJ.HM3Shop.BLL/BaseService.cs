using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.Model;


namespace LYZJ.HM3Shop.BLL
{//服务基类
    public abstract class BaseService<T> where T : class, new()
    {    //当前仓储
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        //创建接口实例
        public IDbSession _DbSession = DbSessionFactory.GetCurrentDbSession();

        public BaseService()
        {
            SetCurrentReposity();//调用子类的实现来为CurrentReposity赋值       在基类里面的构造函数调用父类的纯的抽象方法，那麽经过多态的话最终调用方法的时候去执行子类里面的仓储
        }
        public abstract void SetCurrentReposity();//子类实现
        //数据库添加功能
        public T AddEntity(T entity)
        {
            var AddEntity= CurrentRepository.AddEntity(entity);
            _DbSession.SaveChanges();
            return AddEntity;
        }
        //==================================================== 待完成 ========================================================
        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            return _DbSession.SaveChanges()>0;  
        }
        //====================================================  Update报错  ==================================================
        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            return _DbSession.SaveChanges() > 0;
        }
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        { 
              return CurrentRepository.LoadEntities(whereLambda); 
        }
        public IQueryable<T> LoadPageEntities<S>(int pageIndex,int pageSize,out int total,Func<T,bool>whereLambda,bool isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
