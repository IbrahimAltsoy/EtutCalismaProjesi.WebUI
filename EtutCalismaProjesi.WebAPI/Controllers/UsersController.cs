using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using EtutCalismaProjesi.Service.Concreate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EtutCalismaProjesi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _service;

        public UsersController(IService<User> userService)
        {
            _service = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _service.Find(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<User> PostAsync([FromBody] User user)
        {
            await _service.AddAsync(user);
            await _service.SaveChangesAsync();
            return user;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] User user)
        {
            _service.Update(user);
            await _service.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user = await _service.FindAsync(id);
            _service.Delete(user);
            await _service.SaveChangesAsync();
            return Ok(user);
        }
    }
}
