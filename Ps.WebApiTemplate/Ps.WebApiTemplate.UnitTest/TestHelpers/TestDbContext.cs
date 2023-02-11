namespace Ps.WebApiTemplate.UnitTest.TestHelpers
{
    public class TestDbContext : AppDbContext
    {
        public TestDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubjectMapping>().HasKey(x => new { x.StudId, x.SubId });
            modelBuilder.Seed();
        }
    }
}
