using ElectroShopApi;

public class TaxRateTableContext : DbContext
{
    public TaxRateTableContext(DbContextOptions<TaxRateTableContext> options)
        : base(options)
    {
    }

    public DbSet<TaxRateTable> UserTable { get; set; }
}
