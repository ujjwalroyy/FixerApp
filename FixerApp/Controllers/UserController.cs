using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(long id)
        {
            var user = _userService.getUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.getAllUsers());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] UserDto dto)
        {
            try
            {
                return Ok(_userService.updateUser(id, dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            _userService.deleteUser(id);
            return NoContent();
        }
    }
}
