using AutoMapper;
using LearnOneProvincesVN.Reponsitory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Service.implement
{
    public class ServiceImplement<TEntity, TEntityDtos> : IService<TEntityDtos>
        where TEntityDtos : class
        where TEntity : class
    {
        private readonly IReponsitory<TEntity> _reponsitory;
        private readonly IMapper _mapper;

        public ServiceImplement(IReponsitory<TEntity> reponsitory, IMapper mapper)
        {
            _reponsitory = reponsitory;
            _mapper = mapper;
        }

        public TEntity MapperObject(TEntityDtos entityDtos)
        {
            return _mapper.Map<TEntity>(entityDtos);
        }
        public async Task AddAsync(TEntityDtos entity)
        {

            await _reponsitory.AddAsync(MapperObject(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var result = _reponsitory.GetById(id);
            Console.WriteLine(result);
            if (result != null)
            {
                await _reponsitory.DeleteAsync(result);
            }
        }

        public IQueryable<TEntityDtos> GetAll()
        {
            return _mapper.ProjectTo<TEntityDtos>(_reponsitory.GetAll());
        }

        public async Task<TEntityDtos> GetByIdAsync(int id)
        {
            var result = _reponsitory.GetById(id);
            return _mapper.Map<TEntityDtos>(result);
        }

        public async Task UpdateAsync(TEntityDtos entity)
        {
            await _reponsitory.UpdateAsync(MapperObject(entity));
        }

    }
}
