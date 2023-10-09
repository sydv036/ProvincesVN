using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Domain.Request
{
    public class ProvincesAddRequest
    {
        public string Provinces_Name { get; set; }
    }
    public class ProvincesUpdateRequest
    {
        public int ID { get; set; }
        public string Provinces_Name { get; set; }
    }

    public class DistrictAddRequest
    {
        public string Districs_Name { get; set; }

        public int? Provinces_ID { get; set; }
    }
    public class DistrictUpdateRequest
    {
        public int ID { get; set; }

        public string Districs_Name { get; set; }

        public int? Provinces_ID { get; set; }
    }
    public class WardsAddRequest
    {
        public string Wards_Name { get; set; }
        public int? Districts_ID { get; set; }
    }
    public class WardsUpdateRequest
    {
        public int ID { get; set; }
        public string Wards_Name { get; set; }
        public int? Districts_ID { get; set; }
    }
}
