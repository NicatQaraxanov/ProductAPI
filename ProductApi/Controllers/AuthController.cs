using AuthService;
using DomainModels.DTOs;
using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IRepository<User> _repository;

        private readonly ILoginRegister _loginRegister;

        public AuthController(IRepository<User> repository, ILoginRegister loginRegister)
        {
            _repository = repository;
            _loginRegister = loginRegister;
        }

        // POST api/<ValuesController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (_repository.GetByUsername(userDto.Username) != null)
                return BadRequest("Username already exists");
            await _loginRegister.Register(userDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            try
            {
                var token = await _loginRegister.Login(userDto);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
