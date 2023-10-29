using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;
using TechTitansAPI.Services.AppUser;

namespace TechTitansAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AppUserController : ControllerBase
	{
		private readonly IAppUserService _service;

		public AppUserController(IAppUserService service)
		{
			_service = service;
		}
		[HttpGet("User/{id}")] 
		public async Task<ActionResult<AppUserGetDTO>> GetUserAsync(int id)
		{
			try
			{
				var user = await _service.GetUserAsync(id);
				if (user == null) return NotFound("User not found");
				return user;
			}
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
		[HttpGet("Tree/{id}")]
        public async Task<ActionResult<List<TreeDTO>>> GetTreesByUserId(int id)
		{
			try
			{
				var trees = await _service.GetTreesByUserIdAsync(id);
				if (trees == null) return NotFound("User not found"); 
				return trees;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
		[HttpPost] 
		public async Task<ActionResult<string>> RegisterUSer(AppUserDTO dto)
		{
			try
			{
				var response = await _service.RegisterUserAsync(dto);
				if (response != "registred") return NotFound(response);
				return Ok(response);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}
		[HttpPost("login-cpf")] 
		public async Task<ActionResult<string>> UserLoginByCPFAsync(LoginCPFDTO dto)
		{
			var response = await _service.UserLoginByCPFAsync(dto);
			if (response == null) return NotFound("User not found");
			return response == "access allowed" ? Ok(response) : BadRequest(response);

        }
		[HttpPost("login-email")]
		public async Task<ActionResult<string>> UserLoginByEmailAsync(LoginEmailDTO dto)
        {
			var response = await _service.UserLoginByEmailAsync(dto);
			if (response == null) return NotFound("User not found");
			return response == "access allowed" ? Ok(response) : BadRequest(response);
        }


        [HttpPut("update/{id}")] 
		public async Task<ActionResult<string>> UpdateUserAsync(AppUserUpdateDTO dto, int id)
		{
			try
			{
				var response = await _service.UpdateUserAsync(dto, id);
				if (response == null) return NotFound("User not found");
				if (response != "updated") return BadRequest("response");
				return Ok(response);
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
				var response = await _service.DeleteUserAsync(id);
				if (response == null) return NotFound("User not found");
				if (response != "deleted") return NotFound("Error");
				return Ok(response);
			}
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
