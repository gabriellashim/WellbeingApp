using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quokka_App.Model;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Data;

namespace WebApplication1
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
            //This line of code here is for registration
            //services.AddDbContext<ConnectionsString>(options => options.UseSqlServer(Configuration.GetConnectionString("WebAppContextConnection")));

            //This line of code here is for emotion table DB
            services.AddDbContext<LeadersAssignedContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebAppContextConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();

           //services.AddDatabaseDeveloperPageExceptionFilter();


           //services.AddDatabaseDeveloperPageExceptionFilter();

           services.AddMvc().AddRazorPagesOptions(options => {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRazorPages(options =>
                {
                    options.Conventions.AuthorizeFolder("/Areas");
                }
            );
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
           
        }
    }
}
