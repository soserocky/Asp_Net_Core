using AspNetCorePractice.Data.Seed;
using AspNetCorePractice.Models.Entities;
using AspNetCorePractice.Models.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Data.DBContext
{
    public class AspNetCorePracticeDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AspNetCorePracticeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Booking>().ToTable("Booking");

            //Seeding data
            modelBuilder.SeedData();
        }

    }
}
