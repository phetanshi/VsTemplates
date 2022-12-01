using AutoMapper;
using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data.Interfaces;
using BlazorWA.ViewModels.Models;

namespace BlazorWA.Api.Services.Definitions
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository sampleRepository;
        private readonly IMapper mapper;
        private readonly ILogger<SampleService> logger;

        public SampleService(ISampleRepository sampleRepository, IMapper mapper, ILogger<SampleService> logger)
        {
            this.sampleRepository = sampleRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<List<UserVM>> GetUsers()
        {
            List<UserVM> users = new List<UserVM>();
            var empList =  await sampleRepository.GetEmployeesAsync();
            mapper.Map(empList, users);
            return users;
        }
    }
}
