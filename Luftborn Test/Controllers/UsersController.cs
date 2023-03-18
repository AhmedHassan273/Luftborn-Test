using Luftborn_Test.Users.Dto;
using Luftborn_Test.Users.Interfaces;
using Luftborn_Test.Users.Models;
using Luftborn_Test.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUserWithIdAsync(int userId, UserDto userDto)
        {
            var userToBeUpdated = await _userService.GetByIdAsync(userId);
            if (userToBeUpdated == null)
            {
                return NotFound();
            }

            userToBeUpdated.PhoneNumber = userDto.PhoneNumber;
            userToBeUpdated.Address = userDto.Address;
            userToBeUpdated.FirstName = userDto.FirstName;
            userToBeUpdated.LastName = userDto.LastName;
            userToBeUpdated.Email = userDto.Email;

            var result = await _userService.UpdateUserAsync(userToBeUpdated);

            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUserWithIdAsync(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);

            return result ? Ok() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync([FromBody] UserDto userDto)
        {
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address,
                IsDeleted = false
            };

            var saveUser = await _userService.AddUserAsync(user);

            return Ok(saveUser);
        }
    }
}