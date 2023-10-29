using CompanyModule.HTTPServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
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
        [HttpGet("{id}")]
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
        [HttpPost("login-cnpj")] 
        public async Task<ActionResult<string>> CompanyLoginByCNPJHTTP(LoginCNPJDTO dto)
        {
            try
            {
                var response = await _service.CompanyLoginByCNPJHTTP(dto);
                if (response == "Company not found") return NotFound("Company not found");
                return response == "access allowed" ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login-email")]
        public async Task<ActionResult<string>> CompanyLoginByEmailHTTP(LoginEmailDTO dto)
        {
            try
            {
                var response = await _service.CompanyLoginByEmailHTTP(dto);
                if (response == "Company not found") return NotFound("Company not found");
                return response == "access allowed" ? Ok(response) : BadRequest(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateCompany(int id, CompanyPutDTO request)
        {
            try
            {
                var response = await _service.UpdateCompanyByIdHTTP(request, id);
                if (response == "Company not found") return NotFound(response);
                else if (response == "error") return BadRequest(response); 
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
                if (response == "Company not found") return NotFound("response");
                if (response == "error") return BadRequest(response);
                return response == "deleted" ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
