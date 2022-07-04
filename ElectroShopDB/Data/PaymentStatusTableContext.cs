using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class PaymentStatusTableContext : DbContext
    {
        public PaymentStatusTableContext(DbContextOptions<PaymentStatusTableContext> options) : base(options) { }

        public DbSet<PaymentStatusTable> PaymentStatusTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentStatusTable>().HasData(
                new PaymentStatusTable
                {
                    Id = ConstantTableId.PaymentStatus.Success,
                    Name = "Success"
                },
                new PaymentStatusTable
                {
                    Id = ConstantTableId.PaymentStatus.Failure,
                    Name = "Failure"
                },
                new PaymentStatusTable
                {
                    Id = ConstantTableId.PaymentStatus.Progress,
                    Name = "Progress"
                }
            );
        }
    }
}
