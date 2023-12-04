using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    

   
    public class UsersController : ControllerBase
    {

        IUserService userService;
        IMapper _mapper;
        ILogger<UsersController> _logger;
        public UsersController(IUserService u, IMapper mapper, ILogger<UsersController> logger)
        {
            userService = u;
            _mapper = mapper;
            _logger = logger;
        }
        [Route("login")]
        // GET api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<User>> Get([FromBody] UserLoginDTO userLoginDTO)
        {
            var email = userLoginDTO.Email;
            var password = userLoginDTO.Password;
            User userAgsist = await userService.getUser(email, password);

            if(userAgsist ==null)
            {
                return NoContent();
            }
            return Ok(userAgsist);

        }


       

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] UserDTO userDTO)
        {
           
            User newUser = _mapper.Map<UserDTO,User>(userDTO);
            await userService.addUser(newUser);
            
            if (newUser == null)
            {
                return null;
            }
            _logger.LogInformation("Login attempted with User Name,{0} and password {1}", userDTO.Email, userDTO.Password);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }




        [HttpPost("check")]
        public int Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await userService.editUser(userToUpdate);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
        //[HttpGet("id")]
        //public async Task<ActionResult> Get(
        //    [FromQuery] int id )
        //{
        //    User userAgsist = await userService.getUserById(id);
        //    if (userAgsist == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(userAgsist);

        //}
    }
}
