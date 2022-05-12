using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class OrderTableContext : DbContext
    {
        public OrderTableContext(DbContextOptions<OrderTableContext> options) : base(options) { }

        public DbSet<OrderTable> OrderTable { get; set; }
    }
}
