using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
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
                    Id = ConstantTableId.Manufacturer.Feder,
                    Name = "Feder",
                    Country = "Poland"
                },
                new ManufacturerTable
                {
                    Id = ConstantTableId.Manufacturer.Itera,
                    Name = "Itera",
                    Country = "Poland"
                },
                new ManufacturerTable
                {
                    Id = ConstantTableId.Manufacturer.Konemi,
                    Name = "Konemi",
                    Country = "Japan"
                }
            );
        }
    }
}
