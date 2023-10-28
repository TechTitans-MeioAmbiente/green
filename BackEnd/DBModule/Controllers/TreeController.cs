using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.Models;
using TechTitansAPI.Services.Tree;

namespace TechTitansAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TreeController : ControllerBase
	{
		private readonly ITreeService _service;

		public TreeController(ITreeService service)
		{
			_service = service;
		}

		[HttpGet("tree/{id}")]
		public async Task<ActionResult<TreeGetDTO>> GetTreeAsync(int id)
		{
			try
			{
				var tree = await _service.GetTreeAsync(id);
				if (tree == null) return NotFound("Tree not found");
				return Ok(tree);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost] 
		public async Task<ActionResult<string>> RegisterTreeAsync(TreeDTO dto)
		{
			try
			{
				var response = await _service.RegisterTreeAsync(dto);
				if (response != "registred") return NotFound("Error");
				return Ok(response);
			}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpPut("update/{id}")]  
		public async Task<ActionResult<string>> UpdateTreeAsync(TreeUpdateDTO dto, int id)
		{
			try
			{
				var response = await _service.UpdateTreeAsync(dto, id);
				if (response == null) return NotFound("Tree not found");
				if (response != "updated") return NotFound("Error");
				return Ok(response);
			}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
		public async Task<ActionResult<string>> DeleteTreeAsync(int id)
		{
			try
			{
				var response = await _service.DeleteTreeAsync(id);
				if (response != "deleted") return NotFound("Error");
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
