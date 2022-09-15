using $ext_projectname$.Domain;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}