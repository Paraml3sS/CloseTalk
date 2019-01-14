using CloseTalk.Domain.Models;
using CloseTalk.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userRepository.GetAsync();

            return users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get([FromBody] int id)
        {
            var localUser = await _userRepository.GetAsync(id);

            if (localUser == null) {
                return NotFound();
            }
            else {
                return Ok(localUser);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] User user)
        {
            var localUser = user.DeepClone();

            return await _userRepository.AddUserAsync(localUser);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put([FromBody] User user) => await _userRepository.UpdateUserAsync(user);

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id) => await _userRepository.DeleteUserAsync(id);
    }
}
