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
    public class DistrictsServiceImpl : ServiceImplement<Districts, DistrictsDtos>, IDistrictsService
    {
        public DistrictsServiceImpl(IReponsitory<Districts> reponsitory, IMapper mapper) : base(reponsitory, mapper)
        {
        }
    }
}
