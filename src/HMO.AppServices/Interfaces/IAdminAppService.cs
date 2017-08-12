using System.Collections.Generic;
using System.Threading.Tasks;
using HMO.AppServices.Models;

namespace HMO.AppServices.Interfaces
{
    public interface IAdminAppService
    {
        Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId);
        Task<IEnumerable<Officer>> GetAllOfficersAsync();
        Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request);
    }
}
