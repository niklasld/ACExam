using System;
using AnimalCrossing.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AnimalCrossing.Areas.Identity.IdentityHostingStartup))]
namespace AnimalCrossing.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AnimalCrossingIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("AnimalCrossingIdentityDbContextConnection")));

                //services.AddIdentity<IdentityUser, IdentityRole>(config =>
                //{
                //    config.SignIn.RequireConfirmedEmail = false;
                //    config.SignIn.RequireConfirmedAccount = false;
                //});

                services.AddDefaultIdentity<IdentityUser>(options =>
                { options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;  
                })
                    .AddEntityFrameworkStores<AnimalCrossingIdentityDbContext>();


            });

        }
    }
}