using CompanyModule.HTTPServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace CompanyModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IHTTPService _service;

        public CompanyController(IHTTPService service)
        {
            _service = service;
        }
        [HttpGet("company/{id}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyAsync(int id)
        {
           try
            {
                var response = await _service.GetCompanyByIdHTTP(id);
                if (response == null) return NotFound("Company not found");
                return Ok(response);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<string>> RegisterCompanyAsync(CompanyDTO dto)
        {
            try
            {
                var response = await _service.RegisterCompanyHTTP(dto);
                if (response == null) return NotFound("Database API's error"); 
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyModel>> UpdateCompany(int id, CompanyDTO request)
        {
            try
            {
                var response = await _service.UpdateCompanyByIdHTTP(request, id);
                if (response == null) return NotFound("Company not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCompanyAsync(int id)
        {
            try
            {
                var response = await _service.DeleteCompanyByIdHTTP(id);
                if (response == null) return NotFound("Company not found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
