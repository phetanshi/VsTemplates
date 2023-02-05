namespace PsTest.UnitTest.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void Update_WhenCalledWithOneObject_ReturnsNothingButDataWillbeUpdatedInDb()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                Employee emp = new Employee { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestUpdated", LastName = "Updated", CreatedBy = DateTime.Now.ToString() };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                repository.Update(emp);

                Employee empTest = repository.GetById<Employee>(1);

                Assert.Equal("TestUpdated", empTest.FirstName);
            }
        }

        [Fact]
        public async Task UpdateAsync_WhenCalledWithOneObject_ReturnsNothingButDataWillbeUpdatedInDb()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                Employee emp = new Employee { EmployeeId = 1, UserId = "CORP\\e999999", FirstName = "TestUpdatedAsync", LastName = "Updated", CreatedBy = DateTime.Now.ToString() };

                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                await repository.UpdateAsync(emp);

                Employee empTest = repository.GetById<Employee>(1);

                Assert.Equal("TestUpdatedAsync", empTest.FirstName);
            }
        }
    }
}
