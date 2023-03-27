using DataAcessLayer.Context;
using DataAcessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataBaseContext _dbContext;
        public GenericRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = await _dbContext.Set<TEntity>()
                .AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = _dbContext.Set<TEntity>()
                .Update(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return _dbContext.Set<TEntity>()
                .Select(i => i);
        }

        public async Task DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
        {
            var item = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Remove(item);
            _dbContext.SaveChangesAsync();
        }
    }
}
