using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _repository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _repository.GetAsync(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var result = await _repository.AddAsync(product);
            if (!result)
                return BadRequest("Somethind bad happened");
            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            try
            {
                await _repository.GetAsync(id);
                try
                {
                    var result = _repository.Update(product);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Something bad happened");
                }
            }
            catch (Exception)
            {
                return NotFound("Product with this id doesnt exist");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _repository.GetAsync(id);
                try
                {
                    var result = _repository.Delete(product);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception)
            {
                return NotFound("Product with this id doesnt exist");
            }
        }
    }
}
