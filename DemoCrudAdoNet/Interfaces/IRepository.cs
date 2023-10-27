using System.Linq.Expressions;

namespace DemoCrudAdoNet.Interfaces;

public interface IRepository<T>
{
    Task<bool> CreateAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);

    Task<T> SelectAsync(Expression<Func<T, bool>> expression);

    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null);
}
