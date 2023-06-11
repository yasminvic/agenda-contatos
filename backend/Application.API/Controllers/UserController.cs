using Domain.DTO;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            UserDTO user = new UserDTO();
            try
            {
                user = await _service.GetById(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            return new ObjectResult(await _service.Save(user));
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Put(UserDTO user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            return new ObjectResult(await _service.Save(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
