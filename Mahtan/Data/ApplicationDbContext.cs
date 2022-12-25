using Mahtan.Models;
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

        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Datum> Profile { get; set; }
        public DbSet<PropertyCat> PropertyCats{ get; set; }
        public DbSet<User> SiteUsers { get; set; }
    }
}
