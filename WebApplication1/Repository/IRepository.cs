using System.Linq.Expressions;

namespace WebApplication1.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(Expression<Func<T, bool>> expression);
        void Add(T entity); 
        void Delete(T entity); 
        void Update(T entity);

    }
}
