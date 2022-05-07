using System;
using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class OrderedProductTableContext : DbContext
    {
        public OrderedProductTableContext(DbContextOptions<OrderedProductTableContext> options) : base(options) { }

        public DbSet<OrderedProductTable> OrderedProductTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Obligatory for the composite primary key
            modelBuilder.Entity<OrderedProductTable>()
                .HasKey(table => new { table.OrderId, table.ProductId });
        }
    }
}
