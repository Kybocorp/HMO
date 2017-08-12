using AutoMapper;
using HMO.AppServices.Interfaces;
using HMO.AppServices.Models;
using HMO.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMO.AppServices
{
    public class InspectionAppService: IInspectionAppService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;

        public InspectionAppService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Inspection>> GetInspectionsByUserIdAsync(int userId)
        {
            return _mapper.Map<IEnumerable<Inspection>>(await _inspectionRepository.GetInspectionsByUserIdAsync(userId));
        }
        public async Task<bool> SaveInspectionAsync(string inspection)
        {
            return await _inspectionRepository.SaveInspectionAsync(inspection);
        }
    }
}
