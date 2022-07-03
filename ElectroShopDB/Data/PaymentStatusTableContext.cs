using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class PaymentStatusTableContext : DbContext
    {
        public PaymentStatusTableContext(DbContextOptions<PaymentStatusTableContext> options) : base(options) { }

        public DbSet<PaymentStatusTable> PaymentStatusTable { get; set; }
    }
}
