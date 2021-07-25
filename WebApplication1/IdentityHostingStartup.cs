using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quokka_App.Data;
using Quokka_App.Model;

[assembly: HostingStartup(typeof(Quokka_App.IdentityHostingStartup))]
namespace Quokka_App
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<WebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebAppContextConnection")));

                //services.AddDefaultIdentity<WebAppUser>(options =>
                //{
                //    options.SignIn.RequireConfirmedAccount = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireUppercase = false;
                //})
                //    .AddEntityFrameworkStores<WebAppContext>();
            });
        }
    }
}


//services.AddIdentity<WebAppUser, IdentityRole>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = false;
//})
//           .AddEntityFrameworkStores<WebAppContext>()
//           .AddDefaultTokenProviders();
//RoleManager<IdentityRole> roleManager)