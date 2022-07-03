using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class PaymentOptionTypeTableContext : DbContext
    {
        public PaymentOptionTypeTableContext(DbContextOptions<PaymentOptionTypeTableContext> options) : base(options) { }

        public DbSet<PaymentOptionTypeTable> PaymentOptionTypeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentOptionTypeTable>().HasData(
                new PaymentOptionTypeTable
                {
                    Id = ConstantTableId.PaymentOption.CreditCard,
                    Name = "CreditCard"
                },
                new PaymentOptionTypeTable
                {
                    Id = ConstantTableId.PaymentOption.BankTransfer,
                    Name = "BankTransfer"
                },
                new PaymentOptionTypeTable
                {
                    Id = ConstantTableId.PaymentOption.PayPal,
                    Name = "PayPal"
                },
                new PaymentOptionTypeTable
                {
                    Id = ConstantTableId.PaymentOption.Cash,
                    Name = "Cash"
                }
            );
        }
    }
}