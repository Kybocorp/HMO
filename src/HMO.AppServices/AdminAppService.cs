using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HMO.AppServices.Interfaces;
using HMO.AppServices.Models;
using HMO.Infrastructure.Interfaces;
using AutoMapper;

namespace HMO.AppServices
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        public AdminAppService(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId)
        {
            return _mapper.Map<IEnumerable<Inspection>>(await _inspectionRepository.GetAllInspectionsAsync(userId));
        }

        public async Task<IEnumerable<Officer>> GetAllOfficersAsync()
        {
            return _mapper.Map<IEnumerable<Officer>>(await _inspectionRepository.GetAllOfficersAsync());
        }
        public async Task<bool> AssignInspectionsAsync(AssignInspectionsRequest assignInspectionsRequest)
        {
            var request = _mapper.Map<Infrastructure.Models.AssignInspectionsRequest>(assignInspectionsRequest);
            return await _inspectionRepository.AssignInspectionsAsync(request);
        }
    }
}
