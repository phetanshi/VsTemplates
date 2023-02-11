using Microsoft.EntityFrameworkCore;
using Ps.WebApiTemplate.Data.DbModels;

namespace Ps.WebApiTemplate.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubjectMapping> StudentSubjectMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubjectMapping>().HasKey(x => new { x.StudId, x.SubId });
            base.OnModelCreating(modelBuilder);
        }
    }
}