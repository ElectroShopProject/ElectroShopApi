using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class ProductCategoryTableContext : DbContext
    {

        public ProductCategoryTableContext(DbContextOptions<ProductTableContext> options) : base(options) { }

        public DbSet<ProductCategoryTable> TaxRateTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryTable>().HasData(
                new ProductCategoryTable
                {
                    Id = ConstantTableId.ProductCategory.Ebook,
                    Name = "Ebook"
                },
                new ProductCategoryTable
                {
                    Id = ConstantTableId.ProductCategory.Storage,
                    Name = "Storage"
                },
                new ProductCategoryTable
                {
                    Id = ConstantTableId.ProductCategory.Others,
                    Name = "Others"
                }
            );
        }
    }
}
