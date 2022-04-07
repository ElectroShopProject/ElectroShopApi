using ElectroShopApi.Services;
using ElectroShopDB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElectroShopApi
{
    public class Startup
    {

        private const string DB_NAME = "InMemoryDatabase";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<UserService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<CartService>();
            services.AddSingleton<PaymentService>();
            services.AddSingleton<SummaryService>();
            services.AddSingleton<OrderService>();

            // TODO Move from here to the DB module
            services.AddDbContext<TaxRateTableContext>(
                options => options.UseInMemoryDatabase(DB_NAME)
            );

            services.AddDbContext<ManufacturerTableContext>(
               options => options.UseInMemoryDatabase(DB_NAME)
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
