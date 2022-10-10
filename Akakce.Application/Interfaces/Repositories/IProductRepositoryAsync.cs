using Akakce.Domain.Entities;

namespace Akakce.Application.Interfaces.Repositories;

public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
{
    Task<bool> IsValidProductAsync(long productId);
}
