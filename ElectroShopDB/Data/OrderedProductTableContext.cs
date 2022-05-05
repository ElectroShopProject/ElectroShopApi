using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class OrderedProductTableContext : DbContext
    {
        public OrderedProductTableContext(DbContextOptions<OrderedProductTableContext> options) : base(options) { }

        public DbSet<OrderedProductTable> OrderedProductTable { get; set; }
    }
}
