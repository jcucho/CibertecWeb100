using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.EntityFramework.Northwind;
using Cibertec.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.MVC
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
            services.AddTransient<IUnitOfWork>(
                option => new NorthwindUnitOfWork(
                        new NorthwindDbContext(
                                new DbContextOptionsBuilder<NorthwindDbContext>()
                                .UseSqlServer("Server=JCUCHO\\SQLEXPRESS;Database=Northwind_Lite; Trusted_Connection=True;MultipleActiveResultSets=True")
                                .Options
                            )
                    ) 
            );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
