using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IUnityOfWork _uof; 

        public ProductController(IUnityOfWork uof)
        {
            _uof = uof;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var product = _uof.ProductRepository.Get().ToList();

            return Ok(product);
        }


        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<IEnumerable<Product>> GetProductById(int id)
        {
            var product = _uof.ProductRepository.GetById(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }   

            return Ok(product);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _uof.ProductRepository.Add(product);
            _uof.Commit();

            return new CreatedAtRouteResult("GetProduct",
                new {id = product.Id }, product);
        }


        [HttpPut] 
        public ActionResult Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _uof.ProductRepository.Update(product);
            _uof.Commit();

            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var product = _uof.ProductRepository.GetById(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _uof.ProductRepository.Delete(product);
            _uof.Commit();

            return Ok();
        }
    }
}
