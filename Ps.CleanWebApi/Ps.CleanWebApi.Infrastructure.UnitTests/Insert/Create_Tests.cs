namespace Ps.CleanWebApi.Infrastructure.UnitTests.Insert;

public class Create_Tests
{
    [Fact]
    public void Create_WhenCalledWithValidEntityObject_InsertsNewRecordIntoDatabase()
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
