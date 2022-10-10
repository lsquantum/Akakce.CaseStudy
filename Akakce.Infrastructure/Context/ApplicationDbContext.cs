using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Akakce.Domain.Entities;

namespace Akakce.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    #region DbSet

    public DbSet<Basket> Baskets { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Seed Data
        builder.Seed();
    }
}
