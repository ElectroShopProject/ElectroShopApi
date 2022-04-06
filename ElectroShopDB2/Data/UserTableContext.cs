using Microsoft.EntityFrameworkCore;

public class UserTableContext : DbContext
{
    public UserTableContext(DbContextOptions<UserTableContext> options)
        : base(options)
    {
    }

    public DbSet<ElectroShopApi.Tables.UserTable> UserTable { get; set; }
}
