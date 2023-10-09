using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service
{
    public interface IService<TEntityDtos> where TEntityDtos : class
    {
        IQueryable<TEntityDtos> GetAll();

        Task AddAsync(TEntityDtos entity);
        Task UpdateAsync(TEntityDtos entity);
        Task DeleteAsync(int id);
        Task<TEntityDtos> GetByIdAsync(int id);

    }
}
