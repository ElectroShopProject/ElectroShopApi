using Microsoft.EntityFrameworkCore;

namespace ElectroShopDB
{
    public class UserTableContext : DbContext
    {
        public UserTableContext(DbContextOptions<UserTableContext> options) : base(options) { }

        public DbSet<UserTable> UserTable { get; set; }
    }
}
