using LearnOneProvincesVN.Data;
using LearnOneProvincesVN.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory.implement
{
    public class WardsReponsitoryImpl : ReponsitoryImplement<Wards>, IWardsReponsitory
    {
        public WardsReponsitoryImpl(ApplicationDbContext context) : base(context)
        {
        }
    }
}
