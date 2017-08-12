using HMO.AppServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMO.AppServices.Interfaces
{
    public interface IInspectionAppService
    {
        Task<IEnumerable<Inspection>> GetInspectionsByUserIdAsync(int userId);
        Task<bool> SaveInspectionAsync(string inspection);
    }
}
