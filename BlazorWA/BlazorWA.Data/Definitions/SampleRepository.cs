using BlazorWA.Data.Database;
using BlazorWA.Domain.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorWA.Data.Definitions
{
    public class SampleRepository : ISampleRepository
    {
        private readonly AppDbContext dbContext;

        public SampleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
    }
}
