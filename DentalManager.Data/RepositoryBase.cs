using DentalManager.Domain.Abstractions;
using System.Linq.Expressions;

namespace DentalManager.Data;

public class RepositoryBase<TEntity> : IRepository<TEntity> 
    where TEntity : class, 
    IEntity<int>
{
    protected readonly DentalManagerDBContext _context;

    public RepositoryBase(DentalManagerDBContext context)
    {
        _context = context;
    }

    public async virtual Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken)
    {
        var includeEntity = _context.Set<TEntity>().Find(entity.Id);

        if (includeEntity == null)
            _context.Set<TEntity>().Add(entity);
        else throw new ArgumentException("This value already in the database");

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual void Delete(int id)
    {
        var entity = _context.Set<TEntity>().Find(id);

        if (entity != null)
            _context.Set<TEntity>().Remove(entity);
        else
            throw new Exception("Not found");
    }

    public async virtual Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual TEntity? GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>()
          .Where(predicate);
    }
}
