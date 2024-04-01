using System.Linq.Expressions;

namespace MathQuestAPI.Repository
{
    public interface IRepository<TEntity>
    {
        //CREATE
        Task<int> Add(TEntity change);
        // READ
        Task<TEntity?> GetById(int id);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        // UPDATE
        Task<bool> Update(TEntity change);
        // DELETE
        Task<bool> Delete(int id);
    }
}
