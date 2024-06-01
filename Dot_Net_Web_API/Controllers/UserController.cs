using AutoMapper;
using Dot_Net_Web_API.Interfaces;
using Dot_Net_Web_API.Models;
using Dot_Net_Web_API.Repository;
using KryptoReviewApp.Dto;
using KryptoReviewApp.Interfaces;
using KryptoReviewApp.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dot_Net_Web_API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository UserRepository , IMapper mapper) 
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUser()
        {
            var users = await _UserRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(200 , Type = typeof(IEnumerable<Users>))]
        public IActionResult GetUser(int id)
        {
            var users = _mapper.Map<UserDTO>(_UserRepository.GetUser(id));
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("username/{Name}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        public IActionResult GetUserName(string Name)
        {
            var usersname = _mapper.Map<UserDTO>(_UserRepository.GetUser(Name));
            if (usersname == null)
                return NotFound();
            return Ok(usersname);
        }

        [HttpGet("Email/{Email}")]
        [ProducesResponseType(200, Type = typeof(Users))]
        [ProducesResponseType(400)]
        public IActionResult GetUserEmail(string Email)
        {
            var usersemail = _mapper.Map<UserDTO>(_UserRepository.GetUserEmail(Email));
            if (usersemail == null)
                return NotFound();
            return Ok(usersemail);
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<Users>(userDto);
                var createdUser = await _UserRepository.CreateUserAsync(user);
                var createdUserDto = _mapper.Map<UserDTO>(createdUser);
                return CreatedAtAction("GetUser", new { id = createdUserDto.UserID }, createdUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UserId")]
        [ProducesResponseType(200)]
        public IActionResult UpdateUser(int userid , [FromBody] UserDTO UpdateUser)
        {
            try
            {
                if (userid != UpdateUser.UserID)
                    return BadRequest("User ID mismatch");

                var UserToUpdate = _mapper.Map<Users>(UpdateUser);

                if (UserToUpdate == null)
                    return NotFound($"User with Id = {userid} not found");

                var updateResult = _UserRepository.UpdateUser(UserToUpdate);
                if (updateResult)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("UserId")]
        [ProducesResponseType(200)]
        public IActionResult DeleteUser(int userid)
        {
            var UserToDelete = _UserRepository.GetUser(userid);
            if (!ModelState.IsValid)
                return BadRequest();

                if(!_UserRepository.DeleteUser(UserToDelete))
                {
                ModelState.AddModelError("", "SomeThing Went Wrong");
                }

            return NoContent();
        }
    }
}
