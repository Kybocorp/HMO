using Dapper;
using HMO.Core.Helpers;
using HMO.Core.Models;
using HMO.Infrastructure.Interfaces;
using HMO.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HMO.Infrastructure
{
    public class InspectionRepository : BaseRepository, IInspectionRepository
    {
        private readonly ILogger<InspectionRepository> _logger;
        private readonly IXmlHelper _xmlHelper;
        public InspectionRepository(IConfiguration config, ILogger<InspectionRepository> logger, IXmlHelper xmlHelper) : base(config)
        {
            _logger = logger;
            _xmlHelper = xmlHelper;
        }

        public async Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("UserId", userId, dbType: DbType.Int32);

                _logger.LogInformation("Calling stored procedure api.GetPendingInspections with UserId:  {0}", userId);

                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Inspection, Models.Officer, Tenant, Address, Inspection>("api.GetPendingInspections", (inspection, officer, tenant, address) =>
                    {
                        inspection.Tenant = tenant;
                        inspection.Address = address;
                        inspection.Officer = officer;
                        return inspection;
                    }, param, splitOn: "OfficerId,TenantId, PropertyId", commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Models.Officer>> GetAllOfficersAsync()
        {
            try
            {
                _logger.LogInformation("Calling stored procedure api.GetOfficers");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Models.Officer>("api.GetOfficers", commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Inspection>> GetInspectionsByUserIdAsync(int userId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("UserId", userId, dbType: DbType.Int32);

                _logger.LogInformation("Calling stored procedure api.GetUserPendingInspections with UserId:  {0}", userId);

                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Inspection, Models.Officer, Tenant, Address, Inspection>("api.GetUserPendingInspections", (inspection, officer, tenant, address) =>
                    {
                        inspection.Tenant = tenant;
                        inspection.Address = address;
                        inspection.Officer = officer;
                        return inspection;
                    }, param, splitOn: "OfficerId,TenantId, PropertyId", commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveInspectionAsync(string inspection)
        {
            try
            {
                _logger.LogInformation("Calling stored procedure api.SaveInspection with inspection XML:{0}", inspection);
                var param = new DynamicParameters();
                param.Add("Inspection", inspection, dbType: DbType.Xml);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("api.SaveInspection", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("UserId", request.OfficerId, dbType: DbType.Int32);
                param.Add("AssignedBy", request.AssignedById, dbType: DbType.Int32);
                param.Add("Inspections", String.Join("|", request.InspectionIds), dbType: DbType.String);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure api.AssignInspections with Parameters:[UserId: {0}, AssignedBy:{1},Inspections :[{2}]",
                                        request.OfficerId, request.AssignedById, string.Join("|", request.InspectionIds));

                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("api.AssignInspections", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
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
