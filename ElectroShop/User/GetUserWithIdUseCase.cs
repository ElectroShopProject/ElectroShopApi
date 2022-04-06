using System;
using System.Collections.Generic;
using ElectroShopApi.Domain.User;

#nullable enable
namespace ElectroShop
{
    public class GetUserWithIdUseCase
    {
        public static User? Get(List<User> users, Guid id)
        {
            return users.Find(user => user.Id == id);
        }
    }
}
