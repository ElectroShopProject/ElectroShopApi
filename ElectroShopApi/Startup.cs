using ElectroShopApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

#nullable enable
namespace ElectroShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Called #1
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ElectroShopDB.Program.ConfigureServices(services);
            services.AddCors(options =>
            {
                options.AddPolicy(
                 "AllowOrigin",
                 builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElectroShopApi", Version = "v1" });
             });
            services.AddControllers();
            services.AddTransient<UserService>();
            services.AddTransient<ProductService>();
            services.AddTransient<CartService>();
            services.AddTransient<PaymentService>();
            services.AddTransient<SummaryService>();
            services.AddTransient<OrderService>();
        }

        // Called #2
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ElectroShopDB.Program.Configure(app);

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                // middleware Swagger JSON
                app.UseSwagger();
                // middleware swagger-ui (HTML, JS, CSS, etc.),
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ElectroShopApi v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
