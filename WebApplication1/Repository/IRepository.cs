using System.Linq.Expressions;

namespace WebApplication1.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> expression);
        T Add(T entity); 
        T Delete(T entity); 
        T Update(T entity);

    }
}
