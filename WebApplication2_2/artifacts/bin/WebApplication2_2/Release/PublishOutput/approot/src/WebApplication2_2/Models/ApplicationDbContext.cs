
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using WebApplication2_2.Models;

namespace WebApplication2_2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<HallOfFame> HallOfFame { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }


    }
}
