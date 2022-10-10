using Akakce.Domain.Entities;

namespace Akakce.Application.Interfaces.Repositories;

public interface IStockRepositoryAsync : IGenericRepositoryAsync<Stock>
{
    Task<bool> IsStockEnoughAsync(int quantity, long productId);
}
