using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class PaymentOptionTypeTableContext : DbContext
    {
        public PaymentOptionTypeTableContext(DbContextOptions<PaymentOptionTypeTableContext> options) : base(options) { }

        public DbSet<PaymentOptionTypeTable> PaymentOptionTypeTable { get; set; }
    }
}
