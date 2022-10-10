using Akakce.Application.Interfaces;
using Akakce.Domain.Common;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Infrastructure.Persistence.Repositories;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : AuditableBaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public GenericRepositoryAsync(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<int> GetCountAsync()
    {
        return await _dbContext.Set<T>().Where(e => e.IsDeleted != true).CountAsync();
    }

    public virtual async Task<T?> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().Where(e => e.IsDeleted != true && e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().Where(e => e.IsDeleted != true).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async void AddRange(IEnumerable<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }
}
