using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly IUnityOfWork _uof;

        public CategoryController(IUnityOfWork uof)
        {
            _uof = uof;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var produtos = _uof.CategoryRepository.Get().ToList();

            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<IEnumerable<Category>> GetCategoryById(int id)
        {
            var category = _uof.CategoryRepository.GetById(p => p.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            _uof.CategoryRepository.Add(category);
            _uof.Commit();

            return new CreatedAtRouteResult("GetCategory",
                new { id = category.Id }, category);  

        }


        [HttpPut]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();

            }

            _uof.CategoryRepository.Update(category);
            _uof.Commit();

            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var category = _uof.CategoryRepository.GetById(c => c.Id == id);
            
            if (category == null )
            {
                return NotFound();
            }

            _uof.CategoryRepository.Delete(category);
            _uof.Commit();

            return Ok();
        }
    }
}
