using LearnOneProvincesVN.Data;
using LearnOneProvincesVN.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory.implement
{
    public class ProvincesReponsitoryImpl : ReponsitoryImplement<Provinces>, IProvinceReponsitory
    {
        public ProvincesReponsitoryImpl(ApplicationDbContext context) : base(context)
        {
        }
    }
}
