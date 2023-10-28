using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace CompanyModule.HTTPServices
{
    public interface IHTTPService
    { 
        Task<CompanyModel> GetCompanyByIdHTTP(int id);
        Task<string> RegisterCompanyHTTP(CompanyDTO dto);
        Task<CompanyModel> UpdateCompanyByIdHTTP(CompanyDTO dto, int id); 
        Task<string> DeleteCompanyByIdHTTP(int id);
        Task<string> CompanyLoginByCNPJHTTP(LoginCNPJDTO dto);
        Task<string> CompanyLoginByEmailHTTP(LoginEmailDTO dto);

    }
}
