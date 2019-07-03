using System;
using Blic_tur.Areas.Identity.Data;
using Blic_tur.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Blic_tur.Areas.Identity.IdentityHostingStartup))]
namespace Blic_tur.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlicTurContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("BlicTurContextConnection")));

                services.AddDefaultIdentity<BlicTurUser>()
                    .AddEntityFrameworkStores<BlicTurContext>();
            });
        }
    }
}