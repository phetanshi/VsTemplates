namespace Ps.CleanWebApi.Infrastructure.UnitTests.Update;

public class Update_Tests
{
    [Fact]
    public void Update_WhenCalled_UpdatesTheRecordInTheDatabase()
    {
        Mock<ILogger<AppRepository>> mockLogger = new Mock<ILogger<AppRepository>>();
        var dbOptions = DatabaseCreator.CreateTestDatabase();
        using (var testDbContext = new TestDatabaseContext(dbOptions))
        {
            AppRepository repo = new AppRepository(testDbContext, mockLogger.Object);

            //Logic pending


            //Assert.True(employees.Count == 5);
        }
    }
}
