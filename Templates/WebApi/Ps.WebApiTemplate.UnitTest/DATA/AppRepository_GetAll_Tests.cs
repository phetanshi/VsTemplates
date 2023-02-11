namespace $safeprojectname$.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void GetAll_WhenCalled_ReturnsAllRecords()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<Employee> result = repository.GetAll<Employee>().ToList();

                Assert.Equal(3, result?.Count);
            }
        }
        [Fact]
        public void GetAll_WhenCalledWithExpression_ReturnsFilteredRecords()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<Employee> result = repository.GetAll<Employee>(x => x.EmployeeId == 1).ToList();

                Assert.Equal(1, result?.Count);
            }
        }

        [Fact]
        public async Task GetAllAsync_WhenCalled_ReturnsAllRecords()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<Employee> result = (await repository.GetAllAsync<Employee>()).ToList();

                Assert.Equal(3, result?.Count);
            }
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithExpression_ReturnsFilteredRecords()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                List<Employee> result = (await repository.GetAllAsync<Employee>(x => x.EmployeeId == 1)).ToList();

                Assert.Equal(1, result?.Count);
            }
        }
    }
}
