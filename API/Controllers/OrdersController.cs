using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersService _IOrdersService;
        IMapper _mapper;
        public OrdersController(IOrdersService IOrdersService , IMapper mapper)
        {

            _IOrdersService = IOrdersService;
            _mapper = mapper;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

 

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
        {

            Order order1 = _mapper.Map<OrderDTO, Order>(order);
            OrderReturnDTO newOrder = _mapper.Map<Order, OrderReturnDTO>(await _IOrdersService.addOrder(order1));
            if (newOrder == null)
            {
                return NoContent();
            }

            return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);

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
