using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blic_tur.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blic_tur.Models
{
    public class BlicTurContext : IdentityDbContext<BlicTurUser>
    {
        IConfiguration Configuration { get; }
        public BlicTurContext(DbContextOptions<BlicTurContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);
     
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
