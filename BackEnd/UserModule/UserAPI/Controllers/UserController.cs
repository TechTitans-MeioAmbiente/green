using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTitansAPI.DTOs;
using UserAPI.DTOs;
using UserAPI.Services.User;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<AppUserGetDTO>> GetUser(int id)
        {
            try
            {
                var result = await _userService.GetUserHTTP(id);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tree/{id}")]
        public async Task<ActionResult<List<TreeDTO>>> GetTreesByUserId(int id)
        {
            try
            {
                var result = await _userService.GetTreesByUserIdHTTPAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> RegisterUser(AppUserDTO dto)
        {
            try
            {
                var response = await _userService.RegisterUserHTTP(dto);
                if (response != "registred") return NotFound(response);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<string>> UpdateUserAsync(AppUserUpdateDTO dto, int id)
        {
            try
            {
                var response = await _userService.UpdateUserHTTP(dto, id);
                if (response == "User not found") return NotFound(response);
                return response == "updated" ? Ok(response) : BadRequest(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<string>> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _userService.DeleteUserHTTPAsync(id);
                if (response == "User not found") return NotFound(response);
                return response == "deleted" ? Ok(response) : BadRequest(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
