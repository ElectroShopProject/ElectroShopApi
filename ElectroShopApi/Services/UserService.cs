using System;
using System.Collections.Generic;
using ElectroShop;
using ElectroShopApi.Domain.User;

#nullable enable
namespace ElectroShopApi
{
    public class UserService
    {
        private readonly List<User> Users = new();

        public User? GetUser(Guid userId)
        {
            return GetUserWithIdUseCase.Get(Users, userId);
        }

        public User CreateUser(string userName)
        {
            return CreateUserUseCase.Create(userName);
        }
    }
}
