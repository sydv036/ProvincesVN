using LearnOneProvincesVN.Data.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Data.Entity
{
    public class Districts : IEntity<int>
    {
        public int ID { get; set; }

        public string Districs_Name { get; set; }

        public int? Provinces_ID { get; set; }

        public ICollection<Wards> Wards { get; set; }
        public virtual Provinces Provinces { get; set; }
    }
}
