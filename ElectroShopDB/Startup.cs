using System;
using ElectroShopDB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectroShopDB
{
    public class Startup
    {
        public Startup()
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Console.Write("ConfigureServices");
            // services.AddDbContext<TaxRateTableContext>(
            //     options => options.UseInMemoryDatabase("InMemoryDatabase")
            // );

            // services.AddDbContext<ManufacturerTableContext>(
            //    options => options.UseInMemoryDatabase("InMemoryDatabase")
            //);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
