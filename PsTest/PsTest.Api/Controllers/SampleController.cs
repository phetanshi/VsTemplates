using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsTest.Api.Auth;
using PsTest.Api.Services.Interfaces;

namespace PsTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : AppBaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService, IConfiguration config, ILogger<SampleController> logger) : base(config, logger)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            List<IdentityVM> data = await _sampleService.GetUsers();
            return OkWrapper(data);
        }
    }
}
