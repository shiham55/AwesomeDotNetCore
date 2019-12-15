using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AwesomeDotNetCore.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        public  IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        public  TEntity GetByID(object id);

        public  void Insert(TEntity entity);

        public  void InsertRange(List<TEntity> entity);

        public  void Delete(int id);

        public  void Delete(TEntity entityToDelete);

        public  void Update(TEntity entityToUpdate);

        public  IEnumerable<TEntity> GetPage(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int page = 1,
            int pageSize = 10);
    }
}
