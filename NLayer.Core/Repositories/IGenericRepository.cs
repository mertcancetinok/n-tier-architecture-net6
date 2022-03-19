using System.Linq.Expressions;

namespace NLayer.Core.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
    IQueryable<T> Where(Expression<Func<T,bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    Task<T> AddRangeAsync(IEnumerable<T> entity);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
}