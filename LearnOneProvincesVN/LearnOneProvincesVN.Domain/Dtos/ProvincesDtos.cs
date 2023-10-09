using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Domain.Dtos
{
    public class ProvincesDtos
    {
        public int ID { get; set; }
        public string Provinces_Name { get; set; }

        public ICollection<DistrictsDtos> Districts { get; set; }
    }
}
