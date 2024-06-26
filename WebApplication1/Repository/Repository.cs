﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.DataContext;

namespace WebApplication1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T,
        bool>> predicate)
        {
            return _context.Set<T>()
            .SingleOrDefault(predicate);
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity)
                    .State = EntityState.Modified;
            _context.Set<T>().Update(entity);

            return entity;
        }
    }
}
