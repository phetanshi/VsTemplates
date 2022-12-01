using $ext_projectname$.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    public interface ISampleRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
