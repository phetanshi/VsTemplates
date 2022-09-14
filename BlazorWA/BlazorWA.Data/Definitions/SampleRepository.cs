using BlazorWA.Data.Database;
using BlazorWA.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
