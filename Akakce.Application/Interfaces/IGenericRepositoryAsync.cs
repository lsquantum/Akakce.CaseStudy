namespace Akakce.Application.Interfaces;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<int> GetCountAsync();
    Task<T?> GetByIdAsync(long id);
    Task<IList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}
