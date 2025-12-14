using EmployeeCrudProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudProject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // This DbSet must match the name you use in the controller (Employees)
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salary { get; set; }
    }
}
