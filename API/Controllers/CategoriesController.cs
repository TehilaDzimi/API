using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesService _ICategoriesService;
        IMapper _mapper;
        public CategoriesController(ICategoriesService ICategoriesService, IMapper mapper)
        {
            _ICategoriesService = ICategoriesService;
            _mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {

            IEnumerable<Category> CategoryList = await _ICategoriesService.GetCategoriesAsync();
            IEnumerable<CategoryDTO> CategoryListDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(CategoryList);
            return CategoryListDTO;

        }
        

    }
}
