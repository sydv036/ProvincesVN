using LearnOneProvincesVN.Data.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Data.Entity
{
    public class Wards : IEntity<int>
    {
        public int ID { get; set; }
        public string Wards_Name { get; set; }
        public int? Districts_ID { get; set; }

        public virtual Districts Districts { get; set; }
    }
}
