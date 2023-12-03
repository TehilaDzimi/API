using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //IProductService _productService;
        ICategoriesService _categoryServices;
        IMapper _mapper;
        public CategoriesController(ICategoriesService categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            IEnumerable<Category> category= await _categoryServices.GetCategoryAsync();
            IEnumerable<CategoryDTO> categoryDto = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(category);
            return categoryDto;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
