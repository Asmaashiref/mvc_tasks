using Microsoft.EntityFrameworkCore;

namespace task2.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Companydatabase;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<dependant>().HasKey(d => new { d.essn, d.dependant_name });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<employee> Employees { get; set; }
        public DbSet<department> Departments { get; set; }
        public DbSet<dependant> Dependants { get; set; }
        public DbSet<project> Projects { get; set; }
        public DbSet<works_for> works_Fors { get; set; }
        
    }
}
