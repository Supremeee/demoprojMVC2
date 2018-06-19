using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using demoprojMVC.DALFactory;
using demoprojMVC.IDAL;

namespace demoprojMVC.BLL
{
    public abstract class BaseService<T> where T: class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }

        public IDbSession DbSession { get {return DbSessionFactory.GetCurrentDbSession(); } }

        public BaseService()//基类构造方法
        {
            SetCurrentDal();//抽象方法
        }

        public abstract void SetCurrentDal();//需要子类实现的抽象方法

        #region 查询

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {  
            return CurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntites<TKey>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }
        #endregion
        #region CUD

        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }

        public virtual bool Delete(string id)
        {
            CurrentDal.Delete(id);
            return DbSession.SaveChanges() > 0;
        }
        public bool Delete(List<string> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Delete(id);
            }
            return DbSession.SaveChanges() > 0;
        }

        public bool Audit(string id)
        {
            CurrentDal.Audit(id);
            return DbSession.SaveChanges() > 0;
        }
        public bool Lock(string id)
        {
            CurrentDal.Lock(id);
            return DbSession.SaveChanges() > 0;
        }
        #endregion
    }
}
