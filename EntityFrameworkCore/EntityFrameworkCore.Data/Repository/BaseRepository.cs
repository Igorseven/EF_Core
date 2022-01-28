using EFCore.Business.Interfaces.Repository;
using EFCore.Data.EntityFramework.Context;
using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Data.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>, IDisposable where TEntity : BaseEntity, new()
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<TEntity> Dbset => this._dbContext.Set<TEntity>(); 

        public BaseRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public void Dispose() => _dbContext.Dispose();

        protected async Task SaveAsync() => await this._dbContext.SaveChangesAsync();

        public virtual async Task CreatAsync(TEntity entity)
        {
            Dbset.Add(entity);

            await SaveAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;

            await SaveAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Deleted;

            await SaveAsync();
        }

        public virtual async Task DeleteByIdAsync(TKey id)
        {
            TEntity entity = await FindByAsync(id);

            await DeleteAsync(entity);
        }

        public  async Task<TEntity> FindByAsync(TKey id) => await Dbset.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null) => await FilterBy(where).ToListAsync();

        public virtual async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> where) => await  Dbset.Where(where).FirstOrDefaultAsync();

        public virtual IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = Dbset;

            if (where != null)
            {
                query = query.AsNoTracking().Where(where);
            }

            return query.AsNoTracking();
        }
    }
}
