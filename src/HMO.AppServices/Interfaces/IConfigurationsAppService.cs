using System.Threading.Tasks;

namespace HMO.AppServices.Interfaces
{
    public interface IConfigurationsAppService
    {
        Task<string> GetHmoConfigAsync();
    }
}
