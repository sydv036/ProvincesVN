using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Domain.Dtos
{
    public class WardsDtos
    {
        public int ID { get; set; }
        public string Wards_Name { get; set; }
        public int? Districts_ID { get; set; }
    }
}
