using AutoMapper;
using PsTest.Api.Auth;
using PsTest.Api.Services.Interfaces;
using PsTest.Data;
using PsTest.Data.DbModels;

namespace PsTest.Api.Services.Definitions
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
