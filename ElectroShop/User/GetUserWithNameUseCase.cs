using System.Collections.Generic;

#nullable enable
namespace ElectroShop
{
    public class GetUserWithNameUseCase
    {
        public static User? Get(List<User> users, string name)
        {
            return users.Find(user => user.Name == name);
        }
    }
}
