using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Company
{
	public interface ICompanyService
	{
        Task<string> RegisterCompanyAsync(CompanyDTO dto);

        Task<CompanyModel?> GetCompanyAsync(int id);

        Task<string?> DeleteCompanyAsync(int id);

        Task<CompanyModel?> UpdateCompanyAsync(int id, CompanyDTO request);
    }
}
