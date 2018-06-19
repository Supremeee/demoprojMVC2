using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using demoprojMVC.Model;

namespace demoprojMVC.EFDAL
{
    /// <summary>
    /// 职责：封装所有的Dal的公共的CRUD方法
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDal<T> where T : class, new()
    {
        //DataModelContainer Db = new DataModelContainer();
        public DbContext Db { get { return DbContextFactory.GetCurrentDbContext(); } }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TKey">排序关键字</typeparam>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="total">总数</param>
        /// <param name="whereLambda">过滤表达式</param>
        /// <param name="orderbyLambda">排序表达式</param>
        /// <param name="isAsc">是否正序排序，true则为正序，false为倒序</param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<TKey>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderbyLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            IQueryable<T> temp = null;
            if (isAsc)
            {
                temp =
              Db.Set<T>().Where(whereLambda).OrderBy(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
            else
            {
                temp =
                Db.Set<T>().Where(whereLambda).OrderByDescending(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
            return temp;
        }
        /// <summary>
        /// 向DbSet中增加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        /// <summary>
        /// 根据id值删除一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(string id)
        {
            var entity = Db.Set<T>().Find(id);
            if (entity == null)
                return false;
            Db.Set<T>().Remove(entity);
            return true;
        }

        public bool Audit(string id)
        {
            var entity = Db.Set<T>().Find(id);
            if (entity == null)
                return false;
            //如果audit不为null 取反后赋值，否则赋值false
            Db.Entry(entity).Property("audit").CurrentValue = Db.Entry(entity).Property("audit").CurrentValue != null && !(bool)Db.Entry(entity).Property("audit").CurrentValue;
            //TODO:待测试
            return true;
        }
        public bool Lock(string id)
        {
            var entity = Db.Set<T>().Find(id);
            if (entity == null)
                return false;
            Db.Entry(entity).Property("lock").CurrentValue = Db.Entry(entity).Property("lock").CurrentValue != null && !(bool)Db.Entry(entity).Property("lock").CurrentValue;
            //TODO:待测试
            return true;
        }
    }
}