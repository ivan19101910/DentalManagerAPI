using DentalManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.DAL
{
    public class DentalManagerDBContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasData(new Patient() { Id = 1, Address = "test", DateOfBirth = new DateTime(2000, 10, 19), FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+380673646192" });
        }
    }
}
