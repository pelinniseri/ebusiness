using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EBusiness.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EBusiness.Data.Models
{
    public class Context : IdentityDbContext<EBusinessUser, EBusinessRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=ecbusinessDB; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EBusinessUser>().Ignore(c => c.AccessFailedCount)
                                          .Ignore(c => c.UserName)
                                          .Ignore(c => c.NormalizedEmail)
                                          .Ignore(c => c.EmailConfirmed)
                                          .Ignore(c => c.PhoneNumber)
                                          .Ignore(c => c.PhoneNumberConfirmed)
                                          .Ignore(c => c.TwoFactorEnabled)
                                          .Ignore(c => c.LockoutEnd)
                                          .Ignore(c => c.LockoutEnabled)
                                          .Ignore(c => c.AccessFailedCount)
                                          .Ignore(c => c.PhoneNumberConfirmed);
            builder.Entity<EBusinessUser>().ToTable("Users");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins{ get; set; }
    }
}
