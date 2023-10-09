using AutoMapper;
using LearnOneProvincesVN.Data.Entity;
using LearnOneProvincesVN.Domain.Dtos;
using LearnOneProvincesVN.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service.implement
{
    public class ProvincesServiceImpl : ServiceImplement<Provinces, ProvincesDtos>, IProvincesService
    {
        public ProvincesServiceImpl(IReponsitory<Provinces> reponsitory, IMapper mapper) : base(reponsitory, mapper)
        {
        }
    }
}
