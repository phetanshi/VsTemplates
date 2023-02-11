namespace $safeprojectname$.Data
{
    public partial class AppRepositoryTests
    {
        [Fact]
        public void GetById_WhenCalledWithAValidId_ReturnsARecordWhichMatchesWithId()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                Employee emp = repository.GetById<Employee>(1);

                Assert.Equal("TestOne", emp.FirstName);
            }
        }
        [Fact]
        public void GetById_WhenCalledWithAValidCompositKey_ReturnsARecordWhichMatchesWithCompositKey()
        {

            Mock<ILogger<AppRepository>> mockLogging = new Mock<ILogger<AppRepository>>();

            var dbOptions = TestDatabaseHelper.CreateTestDatabase();

            using (var testDbContext = new TestDbContext(dbOptions))
            {
                AppRepository repository = new AppRepository(testDbContext, mockLogging.Object);
                StudentSubjectMapping compositKeyTest = repository.GetById<StudentSubjectMapping>(1, 1);

                Assert.Equal("One One", compositKeyTest.Message);
            }
        }
    }
}
