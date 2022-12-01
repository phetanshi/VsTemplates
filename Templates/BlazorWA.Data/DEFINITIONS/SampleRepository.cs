using $safeprojectname$.Database;
using $safeprojectname$.Interfaces;
using $ext_projectname$.Domain.DbModels;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Definitions
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
