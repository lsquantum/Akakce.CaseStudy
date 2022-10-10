using Akakce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Infrastructure.Context;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //Product
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product 1", Barcode = "PR00001", Description = "PR - 1", Rate = 4.8M },
            new Product { Id = 2, Name = "Product 2", Barcode = "PR00002", Description = "PR - 2", Rate = 3.2M }
        );

        //Stock
        modelBuilder.Entity<Stock>().HasData(
            new Stock { Id = 1, ProductId = 1, Quantity = 5 },
            new Stock { Id = 2, ProductId = 2, Quantity = 7 }
        );

        //User
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "user1", Email = "user1@user1.com", Password = "user1*123", FirstName = "User", LastName = "1" },
            new User { Id = 2, UserName = "user2", Email = "user2@user2.com", Password = "user2*123", FirstName = "User", LastName = "2" }
        );
    }
}
