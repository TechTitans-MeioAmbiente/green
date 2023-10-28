using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechTitansAPI.DTOs;
using UserAPI.Services.Picture;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<string>> AddPictureToTreeAsync(PictureDTO dto, int id)
        {
            try
            {
                var response = await _pictureService.AddPictureToTreeHTTPAsync(dto, id);
                if (response == "Tree not found") return NotFound(response);
                return response == "created" ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
