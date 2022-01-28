using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Business.Interfaces.Repository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task CreatAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(TKey id);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByAsync(TKey id);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> where);
    }
}
