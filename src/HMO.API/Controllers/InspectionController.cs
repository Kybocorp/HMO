using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HMO.AppServices.Models;
using System.Threading.Tasks;
using HMO.AppServices.Interfaces;
using Microsoft.Extensions.Logging;
using HMO.Core.Helpers;
using HMO.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace HMO.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class InspectionController : Controller
    {
        private readonly IInspectionAppService _inspectionAppService;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILogger<InspectionController> _logger;
        public InspectionController(IInspectionAppService inspectionAppService, IXmlHelper xmlHelper, ILogger<InspectionController> logger)
        {
            _inspectionAppService = inspectionAppService;
            _xmlHelper = xmlHelper;
            _logger = logger;
        }
        /// <summary>
        /// Get inspections by userId
        /// </summary>
        /// <returns>list of Inspection object</returns>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<Inspection>> GetInspectionsByUserId(int userId)
        {
            _logger.LogInformation("Calling GetInspectionsByUserId from InspectionController with UserId : {0}", userId);
            return await _inspectionAppService.GetInspectionsByUserIdAsync(userId);
        }

        /// <summary>
        /// Save inspection
        /// </summary>
        /// <returns>200 status code</returns>
        [HttpPost]
        public async Task<IActionResult> SaveInspection([FromBody]InspectionRequest inspectionRequest)
        {
            _logger.LogInformation("Calling SaveInspection from InspectionController with request : {@0}", inspectionRequest);
            if (!ModelState.IsValid) return BadRequest();
            var inspection = _xmlHelper.ConvertToXml(inspectionRequest);
            if (!await _inspectionAppService.SaveInspectionAsync(inspection)) return NotFound();
            return Ok();
        }
    }
}
