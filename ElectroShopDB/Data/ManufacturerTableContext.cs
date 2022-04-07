using System;
using ElectroShopApi.Tables.Product;
using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB.Data
{
    public class ManufacturerTableContext : DbContext
    {
        public ManufacturerTableContext(DbContextOptions<ManufacturerTableContext> options) : base(options) { }

        public DbSet<ManufacturerTable> ManufacturerTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManufacturerTable>().HasData(
                new ManufacturerTable
                {
                    Id = "26c1a403-05a3-4c33-9dd4-41152fb51f8d",
                    Name = "Feder",
                    Country = "Poland"
                }
            );
        }
    }
}
