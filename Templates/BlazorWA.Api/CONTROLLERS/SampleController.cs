using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Data;
using $ext_projectname$.ViewModels.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
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
        [Route("users")]
        [Authorize]
        public async Task<ActionResult<List<UserVM>>> GetUsers()
        {
            return await _sampleService.GetUsers();
        }
    }
}
