using Akakce.Application.Interfaces.Repositories;

namespace Akakce.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBasketRepositoryAsync Baskets { get; }
    IProductRepositoryAsync Products { get; }
    IStockRepositoryAsync Stocks { get; }
    Task<int> CompleteAsync();
}
