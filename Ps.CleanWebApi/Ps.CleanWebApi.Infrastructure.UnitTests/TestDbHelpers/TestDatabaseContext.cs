namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class TestDatabaseContext(DbContextOptions<AppDbContext> options) : AppDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestDbModelForCompositeKeyEntity>().HasKey(x => new { x.Id, x.IdTwo });
        modelBuilder.Entity<TestEmployeeEntity>();
        modelBuilder.Entity<TestLanAccountEntity>();

        modelBuilder.Seed();
    }
}
