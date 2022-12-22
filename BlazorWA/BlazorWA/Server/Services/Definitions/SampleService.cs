using AutoMapper;
using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.DbModels;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.Api.Services.Definitions
{
    public class SampleService : ServiceBase, ISampleService
    {
        public SampleService(IRepository repository, ILogger<SampleService> logger, IConfiguration config, IMapper mapper) : base(repository, logger, config, mapper)
        {
        }
        public async Task<List<UserVM>> GetUsers()
        {
            List<UserVM> users = new List<UserVM>();
            var empList =  await Repository.GetAllAsync<Employee>();
            Mapper.Map(empList, users);
            return users;
        }
    }
}
