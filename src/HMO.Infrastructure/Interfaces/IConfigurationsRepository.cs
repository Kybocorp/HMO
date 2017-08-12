using System.Threading.Tasks;

namespace HMO.Infrastructure.Interfaces
{
    public interface IConfigurationsRepository
    {
        Task<string> GetHmoConfigAsync();
    }
}
