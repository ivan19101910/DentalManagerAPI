using DentalManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.DAL
{
    public class DentalManagerDBContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasData(new Patient() { Id = 1, Address = "test", DateOfBirth = new DateTime(2000, 10, 19), FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+380673646192" },
                new Patient() { Id = 2, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19), FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 3, Address = "test3", DateOfBirth = new DateTime(2002, 12, 19), FirstName = "Maksym", LastName = "Boiko", PhoneNumber = "+380963386182" });

            //modelBuilder.Entity<Customer>()
            //    .HasData(new Customer() { Id = 1, Gender = "male", },
            //    new Customer() { Id = 2, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19), FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
            //    new Customer() { Id = 3, Address = "test3", DateOfBirth = new DateTime(2002, 12, 19), FirstName = "Maksym", LastName = "Boiko", PhoneNumber = "+380963386182" });
        }
    }
}
