using DataAcessLayer.Entity;

namespace BusinessLogicLayer.Repository
{
    public interface IGenericRepository
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
        Task DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
    }
}
