using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hotel_5.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //modelBuilder.Entity<Bookings>()
            //.HasMany(c => c.AmenitiesList)
            //.WithOne(e => e.Bookings);


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Receptionist", NormalizedName = "Receptionist".ToUpper() });
            //modelBuilder.Entity<Amenities>().HasNoKey();
            modelBuilder.Ignore<Amenities>();
        }
    }
}
