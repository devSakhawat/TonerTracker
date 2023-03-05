using System.Linq.Expressions;

namespace TonerTracker.Infrastructure.Contracts
{
   public interface IRepository<T>
   {
      T Add(T entity);

      Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate);

      Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> obj);

      Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

      Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> obj);

      void Update(T entity);

      void Delete(T entity);
   }
}
