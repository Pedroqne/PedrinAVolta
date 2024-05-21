using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Pagination;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IUnityOfWork _uof;
        private readonly IMapper _mapper;

        public ProductController(IUnityOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var product = _uof.ProductRepository.Get().ToList();

            if (product is null)
            {
                return NotFound();
            }

            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);

            return Ok(productDTO);
        }


        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<IEnumerable<ProductDTO>> GetProductById(int id)
        {
            var product = _uof.ProductRepository.GetById(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);

            return Ok(productDTO);
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<ProductDTO>> Get([FromQuery] ProductParameters productParameters)
        {
            var product = _uof.ProductRepository.GetProducts(productParameters);

            var metadata = new
            {
                product.TotalCount,
                product.PageSize,
                product.CurrentPage,
                product.TotalPages,
                product.HasNext,
                product.HasPrevius
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);

            return Ok(productDTO);
        }



        [HttpPost]
        public ActionResult<ProductDTO> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productDTO);

            var newProduct =  _uof.ProductRepository.Add(product);
            _uof.Commit();

            var newProductDTO = _mapper.Map<ProductDTO>(newProduct);

            

            return new CreatedAtRouteResult("GetProduct",
                new {id = newProductDTO.Id }, newProductDTO);
        }


        [HttpPut] 
        public ActionResult<ProductDTO> Put(int id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productDTO);

            var productAtulizado = _uof.ProductRepository.Update(product);
            _uof.Commit();

            var productAtualizadoDTO = _mapper.Map<ProductDTO>(productAtulizado);

            return Ok(productAtualizadoDTO);
        }


        [HttpDelete]
        public ActionResult<ProductDTO> Delete(int id)
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
