using Contracts;
using Entiies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IConfigurationRoot _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddControllersWithViews();
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true;", x =>
            x.MigrationsAssembly("Migrations")));
            //services.AddTransient<Service>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp => ProductCart.GetCart(sp));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
