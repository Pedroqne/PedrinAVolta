using WebApplication1.DataContext;
using WebApplication1.Models;
using WebApplication1.Pagination;

namespace WebApplication1.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductByPrice()
        {
            return Get().OrderBy(p => p.Price).ToList();
        }

        public PagedList<Product> GetProducts(ProductParameters productParameters)
        {
            var products = Get().OrderBy(p => p.Id).AsQueryable();
            var produtosOrdernados = PagedList<Product>.ToPagedList(products, productParameters.PageSize, productParameters.PageNumber);

            return produtosOrdernados;
            
        }
    }
}
