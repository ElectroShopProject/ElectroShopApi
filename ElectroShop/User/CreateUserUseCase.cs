using System;
using ElectroShopApi.Domain.User;

namespace ElectroShop
{
    public class CreateUserUseCase
    {
        public static User Create(string name)
        {
            return new User(Name: name);
        }
    }
}
