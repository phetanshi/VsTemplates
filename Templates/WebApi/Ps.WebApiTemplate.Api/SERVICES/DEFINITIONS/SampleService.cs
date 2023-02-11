using AutoMapper;
using $safeprojectname$.Auth;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.Data.DbModels;

namespace $safeprojectname$.Services.Definitions
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
