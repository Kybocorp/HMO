using HMO.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMO.Infrastructure.Interfaces
{
    public interface IInspectionRepository
    {
        Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId);
        Task<IEnumerable<Inspection>> GetInspectionsByUserIdAsync(int userId);
        Task<bool> SaveInspectionAsync(string inspection);
        Task<IEnumerable<Officer>> GetAllOfficersAsync();
        Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request);
    }
}
