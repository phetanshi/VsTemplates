using BlazorWA.Domain.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorWA.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}