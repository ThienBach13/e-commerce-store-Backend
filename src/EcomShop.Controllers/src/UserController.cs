using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _userService.GetAllAsync(options));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost()]
        public async Task<ActionResult<UserReadDto>> CreateUserAsync([FromBody] UserCreateDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var createdUser = await _userService.CreateAsync(userDto);
            if (createdUser == null)
            {
                return StatusCode(500, "Failed to create user");
            }

            return createdUser;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDto>> UpdateUser(Guid id, UserUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var updatedUser = await _userService.UpdateAsync(id, updateDto);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result)
            {
                return NotFound($"User with ID {id} not found");
            }

            return NoContent();
        }
    }
}