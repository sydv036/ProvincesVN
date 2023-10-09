using LearnOneProvincesVN.Data;
using LearnOneProvincesVN.Data.IEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Reponsitory.implement
{
    public class ReponsitoryImplement<TEntity> : IReponsitory<TEntity> where TEntity : class, IEntity<int>
    {
        private readonly ApplicationDbContext _context;

        public ReponsitoryImplement(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
            _context.SaveChanges();
            return await Task.FromResult(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(p => p.ID == id);
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return await Task.FromResult(entity);
        }
    }
}
