using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroShopDB.Extensions
{
    public static class ServiceExtensions
    {
        public const string DB_NAME = "InMemoryDatabase";

        public static IServiceCollection AddContext<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddDbContext<T>(options => options.UseInMemoryDatabase(DB_NAME));
            return services;
        }

        public static IServiceProvider EnsureCreated<T>(this IServiceProvider provider) where T : DbContext
        {
            using (var serviceScope = provider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                context.Database.EnsureCreated();
            }
            return provider;
        }
    }
}
