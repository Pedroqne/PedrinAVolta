using WebApplication1.DataContext;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Product> GetProductOrderByPrice()
        {
            return Get().OrderBy(p => p.Price).ToList();

        }
    }
}
