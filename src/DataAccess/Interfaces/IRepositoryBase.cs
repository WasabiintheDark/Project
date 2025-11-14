using System.Linq.Expressions;

namespace CompanyWorkload.DataAccess.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll(bool trackChanges = false);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges = false);
    Task<T?> GetByIdAsync(object id, CancellationToken ct = default);
    Task CreateAsync(T entity, CancellationToken ct = default);
    void Update(T entity);
    void Delete(T entity);
}
