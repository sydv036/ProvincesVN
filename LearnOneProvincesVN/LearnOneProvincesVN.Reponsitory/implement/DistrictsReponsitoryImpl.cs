using LearnOneProvincesVN.Data;
using LearnOneProvincesVN.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory.implement
{
    public class DistrictsReponsitoryImpl : ReponsitoryImplement<Districts>, IDistrictsReponsitory
    {
        public DistrictsReponsitoryImpl(ApplicationDbContext context) : base(context)
        {
        }
    }
}
