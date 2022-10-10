using Akakce.Application.Interfaces.Repositories;
using Akakce.Domain.Entities;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Infrastructure.Persistence.Repositories;

public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
{
    private readonly DbSet<Product> _products;
    public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _products = dbContext.Set<Product>();
    }
    public async Task<bool> IsValidProductAsync(long id)
    {
        return await _products.AnyAsync(p => p.Id == id && p.IsDeleted != true);
    }
}
