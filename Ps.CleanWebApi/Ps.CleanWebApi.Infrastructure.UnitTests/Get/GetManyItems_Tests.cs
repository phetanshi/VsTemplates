namespace Ps.CleanWebApi.Infrastructure.UnitTests.Get;

public class GetManyItems_Tests
{
    [Fact]
    public void GetList_WhenCalledWithIsActiveOnlyAsFalse_ReturnsAllItemsIncludingInactive()
    {
        Mock<ILogger<AppRepository>> mockLogger = new Mock<ILogger<AppRepository>>();
        var dbOptions = DatabaseCreator.CreateTestDatabase();
        using (var testDbContext = new TestDatabaseContext(dbOptions))
        {
            AppRepository repo = new AppRepository(testDbContext, mockLogger.Object);
            List<TestEmployeeEntity> employees = repo.GetManyItems<TestEmployeeEntity, int>(false).ToList();

            Assert.True(employees.Count == 5);
        }
    }
}
