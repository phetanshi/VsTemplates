namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class DatabaseCreator
{
    public static DbContextOptions<AppDbContext> CreateTestDatabase()
    {
        var testDbCon = new SqliteConnection("Data Source=:memory:");
        testDbCon.Open();

        DbContextOptions<AppDbContext> dbOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(testDbCon).EnableSensitiveDataLogging().Options;

        using(var testDbContext = new TestDatabaseContext(dbOptions))
        {
            testDbContext.Database.EnsureCreated();
        }
        return dbOptions;
    }
}
