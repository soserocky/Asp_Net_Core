using AspNetCorePractice.Models.Entities;
using AspNetCorePractice.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Data.Seed
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[] {
              new Country() { Id = 1, Name = "USA" },
              new Country() { Id = 2, Name = "UK" },
              new Country() { Id = 3, Name = "India" },
              new Country() { Id = 4, Name = "France" },
              new Country() { Id = 5, Name = "Italy" }
            });

            modelBuilder.Entity<Gender>().HasData(new Gender[] {
              new Gender() { Id = 1, Type = "Male" },
              new Gender() { Id = 2, Type = "Female" }
            });

            modelBuilder.Entity<Person>().HasData(new Person[] {
              new Person() { Id = 1, Name = "Sabyasachi", Gender = 1, Country = 1 },
              new Person() { Id = 2, Name = "Punyasloka", Gender = 1, Country = 2 },
              new Person() { Id = 3, Name = "Sangram", Gender = 1, Country = 3 },
              new Person() { Id = 4, Name = "Rasmi", Gender = 2, Country = 4 },
              new Person() { Id = 5, Name = "Adyasha", Gender = 2, Country = 5 }
            });

            modelBuilder.Entity<Room>().HasData(new Room[] {
              new Room() { Id = 1, Name = "101", Type = RoomType.Normal },
              new Room() { Id = 2, Name = "102", Type = RoomType.Normal },
              new Room() { Id = 3, Name = "103", Type = RoomType.Normal },
              new Room() { Id = 4, Name = "104", Type = RoomType.Normal },
              new Room() { Id = 5, Name = "105", Type = RoomType.Normal }
            });

            modelBuilder.Entity<Booking>().HasData(new Booking[] {
              new Booking() { Id = 1, Email = "sabya9106@gmail.com", Room = 1, IsActive = true, StartDate = new DateTime(2023, 03, 20), EndDate = new DateTime(2023, 03, 28) },
              new Booking() { Id = 2, Email = "bombay.sangram@gmail.com", Room = 2, IsActive = true, StartDate= new DateTime(2023, 03, 20), EndDate = new DateTime(2023, 03, 28) },
              new Booking() { Id = 3, Email = "sabyasachi.patnaik@hotmail.com", Room = 3, IsActive = true, StartDate = new DateTime(2023, 03, 20), EndDate = new DateTime(2023, 03, 28) },
              new Booking() { Id = 4, Email = "abc@gmail.com", Room = 4, IsActive = true, StartDate= new DateTime(2023, 03, 10), EndDate = new DateTime(2023, 03, 12) },
              new Booking() { Id = 5, Email = "xyz@gmail.com", Room = 3, IsActive = true, StartDate= new DateTime(2023, 03, 12), EndDate = new DateTime(2023, 03, 18) }
            });
        }
    }
}
