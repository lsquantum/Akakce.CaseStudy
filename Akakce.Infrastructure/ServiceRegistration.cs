using Akakce.Application.Interfaces;
using Akakce.Application.Interfaces.Repositories;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Akakce.Infrastructure.Persistence.Repositories;
using Akakce.Infrastructure.Persistence.UnitOfWorks;

namespace Akakce.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    _config.GetConnectionString("ApplicationMySQLConnection"), ServerVersion.AutoDetect(_config.GetConnectionString("ApplicationMySQLConnection"))));

            #region Repositories

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IBasketRepositoryAsync, BasketRepositoryAsync>();
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IStockRepositoryAsync, StockRepositoryAsync>();

            #endregion
        }
    }
}
