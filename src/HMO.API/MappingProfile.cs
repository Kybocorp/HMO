using AutoMapper;
using HMO.AppServices.Models;

namespace HMO.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inspection, Infrastructure.Models.Inspection>().ReverseMap();
            CreateMap<Officer, Infrastructure.Models.Officer>().ReverseMap();
            CreateMap<AssignInspectionsRequest, Infrastructure.Models.AssignInspectionsRequest>().ReverseMap();
        }
    }
}
