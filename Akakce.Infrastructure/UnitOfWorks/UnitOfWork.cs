using Akakce.Application.Interfaces;
using Akakce.Application.Interfaces.Repositories;
using Akakce.Infrastructure.Context;
using Akakce.Infrastructure.Persistence.Repositories;

namespace Akakce.Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        #region Define

        public IBasketRepositoryAsync Baskets { get; private set; }
        public IProductRepositoryAsync Products { get; private set; }
        public IStockRepositoryAsync Stocks { get; private set; }

        #endregion

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            #region Define

            Baskets = new BasketRepositoryAsync(_context);
            Products = new ProductRepositoryAsync(_context);
            Stocks = new StockRepositoryAsync(_context);

            #endregion
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
