﻿using AutoMapper;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.ViewModels.Models;

namespace $safeprojectname$.Services.Definitions
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
