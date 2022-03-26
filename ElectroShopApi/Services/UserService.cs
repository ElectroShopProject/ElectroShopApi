using System;
using ElectroShopApi.Domain.User;

namespace ElectroShopApi
{
    public class UserService
    {
        private readonly User CurrentUser = new User("New user");

        public UserService()
        {
        }

        internal User GetUser(Guid userId)
        {
            // TODO In future allow more users
            return CurrentUser with { Id = userId };
        }
    }
}
