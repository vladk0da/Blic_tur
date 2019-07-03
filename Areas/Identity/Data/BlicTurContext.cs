using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blic_tur.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blic_tur.Models
{
    public class BlicTurContext : IdentityDbContext<BlicTurUser>
    {
        public BlicTurContext(DbContextOptions<BlicTurContext> options)
            : base(options)
        {
            Database.EnsureCreated();
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
