using BlazorWA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWA.Data
{
    public interface ISampleRepository
    {
        Task<string> Greet();
        Task<List<Employee>> GetEmployees();
    }
}
