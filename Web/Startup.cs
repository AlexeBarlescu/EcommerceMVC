using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Data;
using Web.Models;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            SqliteConnection conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            services.AddDbContext<AppContext>(opts => opts.UseSqlite(conn));
            services.AddTransient<IDataRepository, EfDataRepository>();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("category&page",
                    "{category}/Page{pageNumber:int}", new { Controller = "Home", Action = "Index"});
                
                endpoints.MapControllerRoute("category",
                    "{category}", new { Controller = "Home", Action = "Index", pageNumber = 1 });
                
                endpoints.MapControllerRoute("products&page",
                    "Products/Page{pageNumber:int}", new { Controller = "Home", Action = "Index"});
                
                endpoints.MapControllerRoute("products",
                    "Products", new { Controller = "Home", Action = "Index", pageNumber = 1 });
                
                endpoints.MapDefaultControllerRoute();
            });
            
            SeedData.Seed(ctx);
        }
    }
}