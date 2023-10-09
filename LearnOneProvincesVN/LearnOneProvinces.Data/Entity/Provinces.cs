using LearnOneProvincesVN.Data.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Data.Entity
{
    public class Provinces : IEntity<int>
    {
        public int ID { get; set; }
        public string Provinces_Name { get; set; }

        public ICollection<Districts> Districts { get; set; }
    }
}
