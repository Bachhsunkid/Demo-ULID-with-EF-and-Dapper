using DemoEF.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Data
{
    public class EmpContext : DbContext
    {
        DbSet<Employee> Employees { get; set; }

        public EmpContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Register the ULID value converter for the Id property
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasConversion(new UlidToStringConverter());

            base.OnModelCreating(modelBuilder);
        }
    }
}
