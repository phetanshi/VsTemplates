using BlazorWA.Api.Services.Interfaces;
using BlazorWA.Data;
using BlazorWA.Data.Constants;
using BlazorWA.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWA.Api.Controllers
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
            List<UserVM> data = await _sampleService.GetUsers();
            return OkWrapper(data);
        }
    }
}
