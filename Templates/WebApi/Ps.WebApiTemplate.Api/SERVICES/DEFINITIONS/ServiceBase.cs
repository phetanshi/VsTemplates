using AutoMapper;
using $ext_projectname$.Data;

namespace $safeprojectname$.Services.Definitions
{
    public abstract class ServiceBase
    {
        public ServiceBase(IRepository repository, ILogger logger, IConfiguration config)
        {
            Repository = repository;
            Logger = logger;
            Config = config;
        }

        public ServiceBase(IRepository repository, ILogger logger, IConfiguration config, IMapper mapper)
        {
            Repository = repository;
            Logger = logger;
            Config = config;
            Mapper = mapper;
        }

        public IRepository Repository { get; }
        public ILogger Logger { get; }
        public IConfiguration Config { get; }
        public IMapper Mapper { get; }
    }
}
