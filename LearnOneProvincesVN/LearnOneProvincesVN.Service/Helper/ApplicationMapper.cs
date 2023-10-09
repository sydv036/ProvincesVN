using AutoMapper;
using LearnOneProvincesVN.Data.Entity;
using LearnOneProvincesVN.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Provinces, ProvincesDtos>().ReverseMap();
            CreateMap<Districts, DistrictsDtos>().ReverseMap();
            CreateMap<Wards, WardsDtos>().ReverseMap();
        }
    }
}
