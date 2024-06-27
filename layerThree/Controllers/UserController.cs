using layerTwo.DTO;
using layerTwo.Interfaces;
using layerTwo.Services;
using Microsoft.AspNetCore.Mvc;

namespace layerThree.Controllers
{
    [Route("/User/")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return users is not null ? Ok(users) : NoContent();
        }
        [HttpGet("WithRents")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersWithRents()
        {
            var users = await _userService.GetUsersWithRentsAsync();
            return users is not null ? Ok(users) : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user is not null ? new ObjectResult(user) : NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO item)
        {
            if (item is null)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserByIdAsync(item.UserId);
            if (user is null)
            {
                return NotFound();
            }
            await _userService.UpdateUserAsync(item);
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _userService.AddUserAsync(item);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(x => x.UserId == id);
            if (user is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return Ok(user);
        }
    }
}
