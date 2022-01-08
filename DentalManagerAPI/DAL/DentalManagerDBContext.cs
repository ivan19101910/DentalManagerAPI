using DentalManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.DAL
{
    public partial class DentalManagerDBContext : DbContext
    {
        public DentalManagerDBContext()
        {

        }

        public DentalManagerDBContext(DbContextOptions<DentalManagerDBContext> options)
            : base(options)
        { 
            
        } 
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
    
        }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Patient");
            });

            DentalManagerDBContextSeeder.Seed(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
