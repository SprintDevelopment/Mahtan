using Mahtan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahtan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "4be0ea48-957a-4271-acfd-60b8a60af166", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "b5f12804-d4c3-4156-a123-cfacb8c756ad" },
                new IdentityRole { Id = "62d2c350-e6a7-4eff-a5c4-45d92cab03df", Name = "SemiAdmin", NormalizedName = "SEMIADMIN", ConcurrencyStamp = "e42d30cb-95e5-49e4-a5b6-68bbc7c162db" },
                new IdentityRole { Id = "cfccee10-9a30-41f0-9d81-809b83520b5b", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "7827abb2-22fc-4d57-a80f-0293376c8487" });

            base.OnModelCreating(builder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> SiteUsers { get; set; }
    }
}
