using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Auth;
using $safeprojectname$.Services.Interfaces;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = PolicyNames.AppPolicyName)]
    public class SampleController : AppBaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService, IConfiguration config, ILogger<SampleController> logger) : base(config, logger)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            List<IdentityVM> data = await _sampleService.GetUsers();
            return OkWrapper(data);
        }
    }
}
