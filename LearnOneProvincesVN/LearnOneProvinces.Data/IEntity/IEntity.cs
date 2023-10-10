using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Data.IEntity
{
    public interface IEntity<TKey> 
    {
        public TKey ID { get; set; }
    }
}
