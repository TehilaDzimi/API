
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using AutoMapper;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // IProductService _productService;
        // GET: api/<ProductsController>
        IProductsService _productServices;
        IMapper _mapper;
        public ProductsController(IProductsService productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> Get(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products = (List<Product>)await _productServices.getProduct(desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductsDTO> productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductsDTO>>(products);
            if (productsDto == null)
                return BadRequest();
            return Ok(productsDto);
        }

    }
}

