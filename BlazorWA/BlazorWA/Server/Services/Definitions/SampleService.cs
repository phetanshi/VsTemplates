using AutoMapper;
using BlazorWA.Api.Auth;
using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.DbModels;

namespace BlazorWA.Api.Services.Definitions
{
    public class SampleService : ServiceBase, ISampleService
    {
        public SampleService(IRepository repository, ILogger<SampleService> logger, IConfiguration config, IMapper mapper) : base(repository, logger, config, mapper)
        {
        }
        public async Task<List<IdentityVM>> GetUsers()
        {
            List<IdentityVM> users = new List<IdentityVM>();
            var empList =  await Repository.GetAllAsync<Employee>();
            Mapper.Map(empList, users);
            return users;
        }
    }
}
