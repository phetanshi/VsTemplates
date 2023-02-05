using $safeprojectname$.Auth;
using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
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
