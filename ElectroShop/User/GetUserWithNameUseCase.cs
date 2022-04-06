using System;
using System.Collections.Generic;
using ElectroShopApi.Domain.User;

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
