using System.Linq.Expressions;

namespace DentalManager.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : IEntity<int>
{
    TEntity? GetById(int id);

    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);

    void Delete(int id);

    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
}
