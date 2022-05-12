using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroShopDB
{
    public static class ServiceExtensions
    {
        public const string DB_NAME = "InMemoryDatabase";

        public static IServiceCollection AddContext<T>(this IServiceCollection services) where T : DbContext
        {
            // NOTE: There is a well known problem with creating many tables for one DB
            // https://github.com/dotnet/efcore/issues/2874
            services.AddDbContext<T>(options => options.UseInMemoryDatabase(DB_NAME + typeof(T).FullName));
            return services;
        }

        public static IServiceProvider EnsureCreated<T>(this IServiceProvider provider) where T : DbContext
        {
            using (var serviceScope = provider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                context.Database.EnsureDeleted();
                var result = context.Database.EnsureCreated();

                Console.Write("For " + typeof(T).FullName);
                Console.WriteLine(" result is " + result);
            }

            return provider;
        }
    }
}
