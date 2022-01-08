using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Models
{
    public class DentalManagerDBContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>()
                .HasData(new Patient() { Id = 0, Address = "test", DateOfBirth = new DateTime(2000, 10, 19), FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+380673646192" });
        }
    }
}
