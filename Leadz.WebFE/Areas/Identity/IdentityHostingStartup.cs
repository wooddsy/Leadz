using System;
using Leadz.WebFE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Leadz.WebFE.Areas.Identity.IdentityHostingStartup))]
namespace Leadz.WebFE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LeadzWebFEContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("LeadzWebFEContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<LeadzWebFEContext>();
            });
        }
    }
}