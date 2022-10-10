using Akakce.Application.Interfaces.Repositories;
using Akakce.Domain.Entities;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Infrastructure.Persistence.Repositories;

public class StockRepositoryAsync : GenericRepositoryAsync<Stock>, IStockRepositoryAsync
{
    private readonly DbSet<Stock> _stocks;
    public StockRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _stocks = dbContext.Set<Stock>();
    }

    public async Task<bool> IsStockEnoughAsync(int quantity, long productId)
    {
        var stock = await _stocks.Where(p => p.ProductId == productId && p.IsDeleted != true).FirstOrDefaultAsync();
        return stock?.Quantity >= quantity;
    }
}
