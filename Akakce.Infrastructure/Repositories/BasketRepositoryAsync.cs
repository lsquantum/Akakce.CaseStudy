using Akakce.Application.Interfaces.Repositories;
using Akakce.Domain.Entities;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Infrastructure.Persistence.Repositories;

public class BasketRepositoryAsync : GenericRepositoryAsync<Basket>, IBasketRepositoryAsync
{
    private readonly DbSet<Basket> _baskets;
    public BasketRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
    {
        _baskets = dbContext.Set<Basket>();
    }
}
