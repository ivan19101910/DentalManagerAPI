﻿using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalManagerAPI.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        protected readonly DentalManagerDBContext _context;

        public BaseRepository(DentalManagerDBContext context)
        {
            _context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var includeEntity = _context.Set<TEntity>().Find(entity.Id);
            if (includeEntity == null)
                _context.Set<TEntity>().Add(entity);
            else throw new ArgumentException("This value already in the database");

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

        public virtual TEntity Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual TEntity GetById(int id)
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
}
