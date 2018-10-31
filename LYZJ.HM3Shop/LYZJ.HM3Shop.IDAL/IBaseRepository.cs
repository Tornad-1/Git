﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYZJ.HM3Shop.IDAL
{
    public interface IBaseRepository<T> where T:class,new()
    {
        T AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        IQueryable<T> LoadEntities(Func<T, bool> whereLambda);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int PageSize, out int total, Func<T, bool>
            whereLambda, bool isAsc, Func<T, S> orderByLambda);
    }
}
