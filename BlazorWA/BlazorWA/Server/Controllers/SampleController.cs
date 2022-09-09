using BlazorWA.Api.Services;
using BlazorWA.Data;
using BlazorWA.ViewModels.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWA.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;
        public SampleController(ISampleService sampleService)
        {
            this._sampleService = sampleService;
        }

        [HttpGet]
        [Route("sampledata")]
        public async Task<ActionResult> GetSampleData()
        {
            var str = await _sampleService.Greet();
            return Ok(str);
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<ActionResult<List<UserVM>>> GetUsers()
        {
            return await _sampleService.GetUsers();
        }
    }
}
