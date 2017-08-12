using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HMO.AppServices.Models;
using HMO.AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HMO.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminAppService _adminAppService;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IAdminAppService adminAppService, ILogger<AdminController> logger)
        {
            _adminAppService = adminAppService;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Inspection>> GetAllInspections(int userId)
        {
            _logger.LogInformation("Calling GetAllInspections from AdminController with userId: {0}", userId);
            return await _adminAppService.GetAllInspectionsAsync(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<Officer>> GetAllOfficers()
        {
            _logger.LogInformation("Calling GetAllOfficers from AdminController");
            return await _adminAppService.GetAllOfficersAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AssignInspections([FromBody] AssignInspectionsRequest request)
        {
            _logger.LogInformation("Calling AssignInspections from AdminController with request: {@0}", request);
            if (!ModelState.IsValid) return BadRequest();
            if (!await _adminAppService.AssignInspectionsAsync(request)) return NotFound();
            return Ok();
        }
    }
}
