using Microsoft.EntityFrameworkCore;
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
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get()
        {
           return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;    
            _context.Set<T>().Update(entity);
        }
    }
}
}
