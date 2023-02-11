using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ps.WebApiTemplate.Api.Auth;
using Ps.WebApiTemplate.Api.Services.Interfaces;

namespace Ps.WebApiTemplate.Api.Controllers
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
