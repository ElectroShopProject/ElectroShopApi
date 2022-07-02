using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class PaymentTableContext : DbContext
    {
        public PaymentTableContext(DbContextOptions<PaymentTableContext> options) : base(options) { }

        public DbSet<PaymentTable> PaymentTable { get; set; }
    }
}
