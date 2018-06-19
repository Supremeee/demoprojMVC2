using System;
using System.Linq;
using System.Linq.Expressions;

namespace demoprojMVC.IDAL
{
    public interface IBaseDal<T> where T: class ,new ()
    {
        #region 查询

        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetPageEntities<TKey>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc);

        #endregion

        #region CUD

        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Delete(string id);
        bool Audit(string id);
        bool Lock(string id);

        #endregion
    }
}