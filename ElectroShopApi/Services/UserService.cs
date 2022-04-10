using System;
using System.Linq;
using System.Threading.Tasks;
using ElectroShop;
using ElectroShopApi.Mappers;
using ElectroShopDB;
using Microsoft.EntityFrameworkCore;

#nullable enable
namespace ElectroShopApi
{
    public class UserService
    {
        private readonly UserTableContext _context;

        public UserService(UserTableContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(Guid userId)
        {
            var users = await _context.UserTable
                .Select(table => UserMapper.Map(table)).ToListAsync();

            return GetUserWithIdUseCase.Get(users, userId);
        }

        public async Task<User?> GetUser(string name)
        {
            var users = await _context.UserTable
                .Select(table => UserMapper.Map(table)).ToListAsync();

            return GetUserWithNameUseCase.Get(users, name);
        }

        public async Task<User> CreateUser(string userName)
        {
            var newUser = CreateUserUseCase.Create(userName);
            try
            {
                await _context.AddAsync(UserMapper.Map(newUser));
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't write user to DB");
            }

            return newUser;
        }
    }
}
