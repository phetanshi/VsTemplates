using $safeprojectname$.Services.Interfaces;
using $ext_projectname$.Domain.Models;
using $ext_projectname$.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ISampleService sampleService, ILogger<SampleController> logger)
        {
            this._sampleService = sampleService;
            this._logger = logger;
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<ActionResult<List<UserVM>>> GetUsers()
        {
            try
            {
                return await _sampleService.GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, AppConstants.ErrorMessages.UNHANDLED_EXCEPTION);
            }
        }
    }
}
