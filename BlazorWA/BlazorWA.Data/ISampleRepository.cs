using BlazorWA.Domain.DbModels;

namespace BlazorWA.Data
{
    public interface ISampleRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
    }
}
