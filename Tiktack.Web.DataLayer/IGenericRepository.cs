using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tiktack.Web.DataLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        Task InsertRange(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
