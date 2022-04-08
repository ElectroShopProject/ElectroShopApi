using System;
using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{

    public class ProductTableContext : DbContext
    {
        public ProductTableContext(DbContextOptions<ProductTableContext> options) : base(options) { }

        public DbSet<ProductTable> ProductTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Seeding products");

            modelBuilder.Entity<ProductTable>().HasData(
                new ProductTable
                {
                    Id = ConstantTableId.Product.GameDevelopmentBook,
                    Name = "Game Development with Unity and C#",
                    NetPrice = 12.85,
                    GrossPrice = 13.4925,
                    ProductCategoryId = ConstantTableId.ProductCategory.Ebook,
                    ManufacturerId = ConstantTableId.Manufacturer.Konemi
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.LargeHardDrive,
                    Name = "500GB Seagul Hard Drive",
                    NetPrice = 299.50,
                    GrossPrice = 323.46,
                    ProductCategoryId = ConstantTableId.ProductCategory.Storage,
                    ManufacturerId = ConstantTableId.Manufacturer.Konemi
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.Smartphone,
                    Name = "Xiaomei Redmi 13 Ultra 256GB 8GB",
                    NetPrice = 1240.00,
                    GrossPrice = 1525.2,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others,
                    ManufacturerId = ConstantTableId.Manufacturer.Feder
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.ScreenCleaner,
                    Name = "Screen Cleaner 500ml",
                    NetPrice = 5.99,
                    GrossPrice = 7.3677,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others,
                    ManufacturerId = ConstantTableId.Manufacturer.Feder
                },
                new ProductTable
                {
                    Id = ConstantTableId.Product.InternetCamera,
                    Name = "Internet Camera 1080p Low light",
                    NetPrice = 120.00,
                    GrossPrice = 147.6,
                    ProductCategoryId = ConstantTableId.ProductCategory.Others,
                    ManufacturerId = ConstantTableId.Manufacturer.Itera
                }
            );

            Console.WriteLine("Seeding products END");
        }
    }
}
