using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Domain.Dtos
{
    public class DistrictsDtos
    {
        public int ID { get; set; }

        public string Districs_Name { get; set; }

        public int? Provinces_ID { get; set; }

        public ICollection<WardsDtos> Wards { get; set; }
    }
}
