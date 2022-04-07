using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class TaxRateTableContext : DbContext
    {
        public TaxRateTableContext(DbContextOptions<TaxRateTableContext> options) : base(options) { }

        public DbSet<TaxRateTable> TaxRateTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRateTable>().HasData(
                new TaxRateTable
                {
                    Id = ConstantTableId.TaxRate.Tax5,
                    Amount = 0.05,
                    ProductCategoryId = ConstantTableId.ProductCategory.Ebook
                },
                new TaxRateTable
                {
                    Id = ConstantTableId.TaxRate.Tax8,
                    Amount = 0.08,
                    ProductCategoryId = ConstantTableId.ProductCategory.Storage
                },
                new TaxRateTable
                {
                    Id = ConstantTableId.TaxRate.Tax23,
                    Amount = 0.23,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others
                }
            );
        }
    }
}