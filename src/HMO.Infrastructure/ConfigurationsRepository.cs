using System;
using System.Threading.Tasks;
using HMO.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Extensions.Logging;

namespace HMO.Infrastructure
{
    public class ConfigurationsRepository : BaseRepository, IConfigurationsRepository
    {
        private readonly ILogger<ConfigurationsRepository> _logger;
        public ConfigurationsRepository(IConfiguration config, ILogger<ConfigurationsRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<string> GetHmoConfigAsync()
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("Result", dbType: DbType.Xml, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure dbo.GetDictionaryList with Parameters:  {@0}", param);

                return await WithConnection(async c =>
                {
                    var result = await c.ExecuteAsync("api.GetDictionaryList", param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@Result");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
