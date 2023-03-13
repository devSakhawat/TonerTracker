using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TonerTracker.DAL;
using TonerTracker.Infrastructure.Contracts;

namespace TonerTracker.Infrastructure.Services
{
   public class Repository<T> : IRepository<T> where T : class
   {
      private readonly TonerTrackerContext context;

      #region Constructor
      public Repository(TonerTrackerContext context)
      {
         this.context = context;
      }
      #endregion Constructor

      #region Add
      public T Add(T entity)
      {
        return context.Set<T>().Add(entity).Entity;
      }
      #endregion Add

      #region QueryAsync
      public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
      {
         return await context.Set<T>().AsQueryable().AsNoTracking().Where(predicate).ToListAsync();
      }

      public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> obj)
      {
         return await context.Set<T>()
            .AsQueryable()
            .AsNoTracking()
            .Where(predicate)
            .Include(obj)
            .ToListAsync();
      }

      //public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> obj)
      //{
      //   return await context.Set<T>()
      //      .AsQueryable()
      //      .AsNoTracking()
      //      .Where(predicate)
      //      .Include(obj)
      //      .ToListAsync();
      //}
      #endregion QueryAsync

      #region FirstOrDefaultAsync
      public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
      {
         return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
      }

      public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T,object>> obj)
      {
         return await context.Set<T>().AsNoTracking().Include(obj).FirstOrDefaultAsync(predicate);
      }
      #endregion FirstOrDefaultAsync

      #region Update
      public void Update(T entity)
      {
         context.Entry(entity).State = EntityState.Modified;
         context.Set<T>().Update(entity);
      }
      #endregion Update

      #region Delete
      public void Delete(T entity)
      {
         context.Entry(entity).State = EntityState.Modified;
         context.Set<T>().Remove(entity);
      }
      #endregion Delete
   }
}