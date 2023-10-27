using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Company
{
	public interface ICompanyService
	{
        Task<CompanyModel?> GetCompanyAsync(int id);
        Task<string> RegisterCompanyAsync(CompanyDTO dto);
        Task<string> CompanyLoginByCNPJAsync(string cnpj, string password);
        Task<string> CompanyLoginByEmailAsync(string email, string password);
        Task<string?> UpdateCompanyAsync(int id, CompanyDTO request);
        Task<string?> DeleteCompanyAsync(int id);

    }
}
