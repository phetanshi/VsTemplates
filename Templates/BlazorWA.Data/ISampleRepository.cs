using $ext_projectname$.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public interface ISampleRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
