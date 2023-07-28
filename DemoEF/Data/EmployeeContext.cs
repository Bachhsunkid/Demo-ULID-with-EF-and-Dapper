using DemoEF.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Data
{
    public class EmployeeContext : DbContext
    {
        DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Register the ULID value converter for the Id property
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasConversion(new StringUlidHandler());

            base.OnModelCreating(modelBuilder);
        }
    }
}
