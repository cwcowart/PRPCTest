using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using prpc.Areas.Identity.Data;

[assembly: HostingStartup(typeof(prpc.Areas.Identity.IdentityHostingStartup))]
namespace prpc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<prpcIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("prpcIdentityDbContextConnection")));

                services.AddDefaultIdentity<PRPCUser>()
                    .AddEntityFrameworkStores<prpcIdentityDbContext>();
            });
        }
    }
}