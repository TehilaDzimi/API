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
    public class OrdersController : ControllerBase
    {
        IOrdersService _orderServices;
        IMapper _mapper;
        public OrdersController(IOrdersService orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);

            Order newOrder = await _orderServices.addOrder(order);
            if (newOrder == null)
            {
                return null;
            }
            OrderDTO data = _mapper.Map<Order, OrderDTO>(newOrder);
            return CreatedAtAction(nameof(Get), new { id = data.OrderId }, data);
        }


        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
