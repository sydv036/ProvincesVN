using AutoMapper;
using LearnOneProvincesVN.Domain.Dtos;
using LearnOneProvincesVN.Domain.Request;

namespace LearnOneProvincesVN.Api.Profiles
{
    public class ModelRequestProfiles : Profile
    {
        public ModelRequestProfiles()
        {
            CreateMap<ProvincesAddRequest, ProvincesDtos>();
            CreateMap<ProvincesUpdateRequest, ProvincesDtos>();
            CreateMap<DistrictAddRequest, DistrictsDtos>();
            CreateMap<DistrictUpdateRequest, DistrictsDtos>();
            CreateMap<WardsAddRequest, WardsDtos>();
            CreateMap<WardsUpdateRequest, WardsDtos>();
        }
    }
}
