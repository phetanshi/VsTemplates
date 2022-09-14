using BlazorWA.Data.Definitions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlazorWA.UnitTest.Data
{
    public class SampleRepositoryTests
    {
        [Fact]
        public async Task GetEmployeesAsync_WhenCalled_ReturnsAllEmployees()
        {
            var testDbConn = new SqliteConnection("DataSource=:memory:");
            testDbConn.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(testDbConn).EnableSensitiveDataLogging().Options;

            using(var testDbContext = new TestDbContext(options))
            {
                testDbContext.Database.EnsureCreated();
            }

            using (var testDbContext = new TestDbContext(options))
            {
                SampleRepository sampleRepository = new SampleRepository(testDbContext);
                var result = await sampleRepository.GetEmployeesAsync();
                var expectedCount = DBDataSets.GetEmployeeTableTestData().Count;

                Assert.Equal(expectedCount, result.Count);
            }
        }
    }
}
