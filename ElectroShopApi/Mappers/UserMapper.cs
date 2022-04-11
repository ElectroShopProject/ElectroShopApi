using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi.Mappers
{
    public class UserMapper
    {
        public static User Map(UserTable table)
        {
            return new User(Name: table.Name) with { Id = table.Id.ToGuid() };
        }

        public static UserTable Map(User user)
        {
            return new UserTable { Id = user.Id.ToString(), Name = user.Name };
        }
    }
}
