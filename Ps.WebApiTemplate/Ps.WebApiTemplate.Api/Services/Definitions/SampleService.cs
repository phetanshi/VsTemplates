using AutoMapper;
using Ps.WebApiTemplate.Api.Auth;
using Ps.WebApiTemplate.Api.Services.Interfaces;
using Ps.WebApiTemplate.Data;
using Ps.WebApiTemplate.Data.DbModels;

namespace Ps.WebApiTemplate.Api.Services.Definitions
{
    public class SampleService : ServiceBase, ISampleService
    {
        public SampleService(IRepository repository, ILogger<SampleService> logger, IConfiguration config, IMapper mapper) : base(repository, logger, config, mapper)
        {
        }
        public async Task<List<IdentityVM>> GetUsers()
        {
            List<IdentityVM> users = new List<IdentityVM>();
            var empList = await Repository.GetAllAsync<Employee>();
            Mapper.Map(empList, users);
            return users;
        }
    }
}
