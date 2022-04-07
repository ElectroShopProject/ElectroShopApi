using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{

    public class ProductTableContext : DbContext
    {
        public ProductTableContext(DbContextOptions<ProductTableContext> options) : base(options) { }

        public DbSet<ProductTable> ProductTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTable>().HasData(
                new ProductTable
                {
                    Id = ConstantTableId.Product.GameDevelopmentBook,
                    Name = "Game Development with Unity and C#",
                    NetPrice = 12.85,
                    GrossPrice = 13.4925,
                    ProductCategoryId = ConstantTableId.ProductCategory.Ebook
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.LargeHardDrive,
                    Name = "500GB Seagul Hard Drive",
                    NetPrice = 299.50,
                    GrossPrice = 323.46,
                    ProductCategoryId = ConstantTableId.ProductCategory.Storage
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.Smartphone,
                    Name = "Xiaomei Redmi 13 Ultra 256GB 8GB",
                    NetPrice = 1240.00,
                    GrossPrice = 1525.2,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.ScreenCleaner,
                    Name = "Screen CĻĻleaner 500ml",
                    NetPrice = 5.99,
                    GrossPrice = 7.3677,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.InternetCamera,
                    NetPrice = 120.00,
                    GrossPrice = 147.6,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others
                }
            );
        }
    }
}
