using Microsoft.AspNetCore.Mvc;
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
    public class ConfigurationsController : Controller
    {
        private readonly IConfigurationsAppService _configurationsAppService;
        private readonly IXmlHelper _xmlHelper;
        private readonly ILogger<ConfigurationsController> _logger;

        public ConfigurationsController(IConfigurationsAppService configurationsAppService, IXmlHelper xmlHelper, ILogger<ConfigurationsController> logger)
        {
            _configurationsAppService = configurationsAppService;
            _xmlHelper = xmlHelper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<Dictionary> GetHmoConfig()
        {
            _logger.LogInformation("Calling GetHmoConfig from ConfigurationsController");
            return _xmlHelper.ConvertFromXml<Dictionary>(await _configurationsAppService.GetHmoConfigAsync());
        }
    }
}
