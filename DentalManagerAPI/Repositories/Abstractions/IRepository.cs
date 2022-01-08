using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using System.Linq.Expressions;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : IEntity<int>
    {
        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        void Delete(int id);

        TEntity Edit(TEntity entity);
    }
}
