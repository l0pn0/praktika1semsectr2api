using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using praktika1semsectr2api.Interface;
using praktika1semsectr2api.Model;
using praktika1semsectr2api.Service;

namespace praktika1semsectr2api.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   [Authorize(Roles = "Admin")]
   public class UsersController : ControllerBase
   {
        private readonly IUsercs _usersService;

        public UsersController(IUsercs userService)
        {
            _usersService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel user)
        {
            var result = await _usersService.CreateUserAsync(user);
            if (!result)
                return BadRequest("Email already exists");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, RegisterModel user)
        {
            if (id != user.id_User)
                return BadRequest();

            var result = await _usersService.UpdateUserAsync(user);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _usersService.DeleteUserAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authenticatedUser = await _usersService.AuthenticationAsync(loginRequest.Email, loginRequest.Password);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }
    }
}
