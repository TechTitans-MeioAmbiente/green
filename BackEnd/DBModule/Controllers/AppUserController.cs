using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TechTitansAPI.DTOs;
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
		[HttpGet("user/{id}")] 
		public async Task<ActionResult<AppUserModel>> GetUserAsync(int id)
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
				if (response != "registred") return NotFound("Error");
				return Ok(response);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}
		[HttpPut("update/{id}")] 
		public async Task<ActionResult<string>> UpdateUserAsync(AppUserUpdateDTO dto, int id)
		{
			try
			{
				var response = await _service.UpdateUserAsync(dto, id);
				if (response == null) return NotFound("User not found");
				if (response != "updated") return NotFound("Error");
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
