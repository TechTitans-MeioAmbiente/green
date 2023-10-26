using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TechTitansAPI.DTOs;
using TechTitansAPI.Services.Picture;

namespace TechTitansAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PictureController : ControllerBase
	{
		private readonly IPictureService _service;

		public PictureController(IPictureService service)
		{
			_service = service;
		}

		[HttpPost("post/{id}")] 
		public async Task<ActionResult<string>> AddPictureToTreeAsync(PictureDTO dto, int id)
		{
			try
			{
				var response = await _service.AddPictureToTreeAsync(dto, id);
				if (response == null) return NotFound("Tree not found");
				if (response != "created") return NotFound("Error");
				return Ok(response);
			} 
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

    }
}
