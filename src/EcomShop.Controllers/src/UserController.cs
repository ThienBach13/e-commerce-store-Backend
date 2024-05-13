using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //query string
        // api/v1/users?firstname=ali&role=admin      
        // [HttpGet]
        // public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync([FromQuery] UserQueryOptions options)
        // {
        //     try
        //     {
        //         return await _userService.GetAllUsersAsync(options);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }
        [HttpGet]
        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            try
            {
                return await _userService.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserReadDto>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        // [HttpPost]
        // public async Task<ActionResult<UserReadDto>> CreateUserAsync(UserCreateDto userDto)
        // {
        //     if (userDto == null)
        //     {
        //         return BadRequest("Invalid request body");
        //     }

        //     var createdUser = await _userService.CreateUserAsync(userDto);
        //     if (createdUser == null)
        //     {
        //         return StatusCode(500, "Failed to create user");
        //     }

        //     return createdUser;
        // }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserReadDto>> UpdateUser(int id, UserUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            updateDto.Id = id;

            var updatedUser = await _userService.UpdateUserByIdAsync(updateDto);

            return Ok(updatedUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserByIdAsync(id);

            if (!result)
            {
                return NotFound($"User with ID {id} not found");
            }

            return NoContent();
        }
    }
}