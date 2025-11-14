using System.Linq.Expressions;
using CompanyWorkload.DataAccess.Interfaces;
using CompanyWorkload.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWorkload.DataAccess.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly CompanyWorkloadDbContext Db;
    protected readonly DbSet<T> Set;

    protected RepositoryBase(CompanyWorkloadDbContext db)
    {
        Db = db;
        Set = db.Set<T>();
    }

    public IQueryable<T> FindAll(bool trackChanges = false) =>
        trackChanges ? Set : Set.AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges = false) =>
        (trackChanges ? Set : Set.AsNoTracking()).Where(predicate);

    public async Task<T?> GetByIdAsync(object id, CancellationToken ct = default) =>
        await Set.FindAsync(new[] { id }, ct);

    public Task CreateAsync(T entity, CancellationToken ct = default)
    {
        Set.Add(entity);
        return Task.CompletedTask;
    }

    public void Update(T entity) => Set.Update(entity);
    public void Delete(T entity) => Set.Remove(entity);
}
