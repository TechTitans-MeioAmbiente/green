using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace CompanyModule.HTTPServices
{
    public interface IHTTPService
    { 
        Task<CompanyGetDTO> GetCompanyByIdHTTP(int id);
        Task<string> RegisterCompanyHTTP(CompanyDTO dto);
        Task<string> UpdateCompanyByIdHTTP(CompanyPutDTO dto, int id); 
        Task<string> DeleteCompanyByIdHTTP(int id);
        Task<string> CompanyLoginByCNPJHTTP(LoginCNPJDTO dto);
        Task<string> CompanyLoginByEmailHTTP(LoginEmailDTO dto);

    }
}
