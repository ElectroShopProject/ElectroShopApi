using System;
using ElectroShopApi;
using Microsoft.EntityFrameworkCore;

public class TaxRateTableContext : DbContext
{
    public TaxRateTableContext(DbContextOptions<TaxRateTableContext> options) : base(options) { }

    public DbSet<TaxRateTable> TaxRateTable { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<TaxRateTable>().HasData(
        //    new TaxRateTable { Id = Guid.NewGuid().ToString(), Amount = 0.05, ProductCategoryId =  },
        //);
    }
}
