using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingList.Models;

namespace ShoppingList
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
            services.AddDbContext<ShoppingDbContext>(opt =>
               opt.UseInMemoryDatabase("ShoppingItems"));
            services.AddControllers();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ShoppingDbContext>();
                AddTestData(context);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client";
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });
        }

        private static void AddTestData(ShoppingDbContext context)
        {
            var item1 = new ShoppingItem
            {
                Id = 1,
                Name = "Apples",
                Amount = 20m,
                Quantity = 5
            };

            var item2 = new ShoppingItem
            {
                Id = 2,
                Name = "Oranges",
                Amount = 22.43m,
                Quantity = 13
            };

            var item3 = new ShoppingItem
            {
                Id = 3,
                Name = "Lemons",
                Amount = 25.43m,
                Quantity = 19
            };

            var item4 = new ShoppingItem
            {
                Id = 4,
                Name = "Xray",
                Amount = 5.43m,
                Quantity = 1
            };

            var item5 = new ShoppingItem
            {
                Id = 5,
                Name = "Xarelto",
                Amount = 15.43m,
                Quantity = 2
            };

            var item6 = new ShoppingItem
            {
                Id = 6,
                Name = "Xalatan",
                Amount = 35.43m,
                Quantity = 17
            };

            var item7 = new ShoppingItem
            {
                Id = 7,
                Name = "Test",
                Amount = 15.43m,
                Quantity = 20
            };

            var item8 = new ShoppingItem
            {
                Id = 8,
                Name = "Mema",
                Amount = 55.43m,
                Quantity = 50
            };

            var item9 = new ShoppingItem
            {
                Id = 9,
                Name = "xbox",
                Amount = 500.43m,
                Quantity = 1
            };

            var item10 = new ShoppingItem
            {
                Id = 10,
                Name = "tablet",
                Amount = 250.43m,
                Quantity = 1
            };

            context.ShoppingItems.AddRange(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10);

            context.SaveChanges();
        }
    }
}
