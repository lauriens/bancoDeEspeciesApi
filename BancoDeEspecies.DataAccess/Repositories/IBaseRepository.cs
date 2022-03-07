using System.Linq.Expressions;

namespace BancoDeEspecies.DataAccess.Configurations
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        Task<TEntity?> GetByID(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}