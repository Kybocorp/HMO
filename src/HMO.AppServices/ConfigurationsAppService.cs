using System;
using System.Threading.Tasks;
using HMO.AppServices.Interfaces;
using HMO.Infrastructure.Interfaces;

namespace HMO.AppServices
{
    public class ConfigurationsAppService: IConfigurationsAppService
    {
        private readonly IConfigurationsRepository _configurationsRepository;
        public ConfigurationsAppService(IConfigurationsRepository configurationsRepository)
        {
            _configurationsRepository = configurationsRepository;
        }

        public async Task<string> GetHmoConfigAsync()
        {
            var result = await _configurationsRepository.GetHmoConfigAsync();
            if (result == null) throw new Exception("HMO App Configurations not found");
            return result;
        }
    }
}
