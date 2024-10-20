namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public static class TestDataSets
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestEmployeeEntity>().HasData(GetTestEmployeeEntities());
        modelBuilder.Entity<TestLanAccountEntity>().HasData(GetTestLanAccounts());
    }
    private static List<TestEmployeeEntity> GetTestEmployeeEntities()
    {
        List<TestEmployeeEntity> employees = new List<TestEmployeeEntity>();
        employees.Add(new TestEmployeeEntity { Id = 1, FirstName = "Padmasekhar", LastName = "Pottepalem", CreatedBy = "test", DateCreated = DateTime.UtcNow, IsActive = true });
        employees.Add(new TestEmployeeEntity { Id = 2, FirstName = "Raju", LastName = "Kamepally", CreatedBy = "test", DateCreated = DateTime.UtcNow, IsActive = true });
        employees.Add(new TestEmployeeEntity { Id = 3, FirstName = "Teju", LastName = "Otturu", CreatedBy = "test", DateCreated = DateTime.UtcNow, IsActive = true });
        employees.Add(new TestEmployeeEntity { Id = 4, FirstName = "Abc", LastName = "LLL", CreatedBy = "test", DateCreated = DateTime.UtcNow, IsActive = false });
        employees.Add(new TestEmployeeEntity { Id = 5, FirstName = "Def", LastName = "KKK", CreatedBy = "test", DateCreated = DateTime.UtcNow, IsActive = false });
        return employees;
    }

    public static List<TestLanAccountEntity> GetTestLanAccounts()
    {
        List<TestLanAccountEntity> accounts = new List<TestLanAccountEntity>();

        accounts.Add(new TestLanAccountEntity { Id = "PAD123", EmployeeId = 1, IsActive = true, CreatedBy = "test", DateCreated = DateTime.UtcNow });
        accounts.Add(new TestLanAccountEntity { Id = "RJU123", EmployeeId = 2, IsActive = true, CreatedBy = "test", DateCreated = DateTime.UtcNow });
        accounts.Add(new TestLanAccountEntity { Id = "TJU123", EmployeeId = 3, IsActive = true, CreatedBy = "test", DateCreated = DateTime.UtcNow });
        accounts.Add(new TestLanAccountEntity { Id = "ABC123", EmployeeId = 4, IsActive = false, CreatedBy = "test", DateCreated = DateTime.UtcNow });
        accounts.Add(new TestLanAccountEntity { Id = "DEF123", EmployeeId = 5, IsActive = false, CreatedBy = "test", DateCreated = DateTime.UtcNow });

        return accounts;
    }
}
