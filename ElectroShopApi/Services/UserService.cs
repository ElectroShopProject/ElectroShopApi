using System;
using System.Collections.Generic;
using ElectroShop;

#nullable enable
namespace ElectroShopApi
{
    public class UserService
    {
        private readonly HashSet<User> Users = new();

        public User? GetUser(Guid userId)
        {
            return GetUserWithIdUseCase.Get(Users.Values(), userId);
        }

        public User? GetUser(string name)
        {
            return GetUserWithNameUseCase.Get(Users.Values(), name);
        }

        public User CreateUser(string userName)
        {
            var newUser = CreateUserUseCase.Create(userName);
            Users.Add(newUser);
            return newUser;
        }
    }
}
