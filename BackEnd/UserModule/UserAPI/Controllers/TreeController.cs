using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;
using UserAPI.Services.Tree;

namespace UserAPI.Controllers
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
        [HttpGet("{id}")]
        public async Task<ActionResult<TreeGetDTO>> GetTreeByIdAsync(int id)
        {
            try
            {
                var response = await _service.GetTreeHTTPAsync(id);
                if (response == null) return NotFound("Tree not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<string>> RegisterTreeAsync(TreeDTO dto)
        {
            try
            {
                var response = await _service.RegisterTreeHTTPAsync(dto);
                if (response == null) return NotFound("Error");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTreeAsync(TreeUpdateDTO dto, int id)
        {
            try
            {
                var response = await _service.UpdateTreeByIdHTTPAsync(dto, id);
                if (response == null) return NotFound("Tree not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTreeByIdAsync(int id)
        {
            try
            {
                var response = await _service.DeleteTreeByIdHTTPAsync(id);
                if (response == null) return NotFound("Tree not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
