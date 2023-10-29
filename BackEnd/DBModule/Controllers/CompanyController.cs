using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;
using TechTitansAPI.Services.Company;

namespace TechTitansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyAsync(int id)
        {
            try
            {
                var company = await _service.GetCompanyAsync(id);
                if (company == null) return NotFound("Company not found");
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<string>> RegisterCompanyAsync(CompanyDTO dto)
        {
            try
            {
                var response = await _service.RegisterCompanyAsync(dto);
                if (response != "registred") return NotFound("Error");
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPost("login-cnpj")]
        public async Task<ActionResult<string>> CompanyLoginByCNPJAsync(LoginCNPJDTO dto)
        {
            var response = await _service.CompanyLoginByCNPJAsync(dto); 
            if (response == null) return NotFound("Company not found");
            return response == "access allowed" ? Ok(response) : BadRequest(response);
        } 
        [HttpPost("login-email")]
        public async Task<ActionResult<string>> CompanyLoginByEmailAsync(LoginEmailDTO dto)
        {
            var response = await _service.CompanyLoginByEmailAsync(dto); 
            if (response == null) return NotFound("Company not found");
            return response == "access allowed" ? Ok(response) : BadRequest(response);
        } 


        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyModel>> UpdateCompany(int id, CompanyPutDTO request)
        {
            var result = await _service.UpdateCompanyAsync(id, request);
            if (result is null)
            {
                return NotFound("Company not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCompanyAsync(int id)
        {
            try
            {
                var response = await _service.DeleteCompanyAsync(id);
                if (response == null) return NotFound("Company not found");
                if (response != "deleted") return BadRequest("Error");
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
