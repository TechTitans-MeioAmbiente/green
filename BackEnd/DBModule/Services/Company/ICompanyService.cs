﻿using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Company
{
    public interface ICompanyService
	{
        Task<CompanyGetDTO?> GetCompanyAsync(int id);
        Task<string> RegisterCompanyAsync(CompanyDTO dto);
        Task<string> CompanyLoginByCNPJAsync(LoginCNPJDTO dto);
        Task<string> CompanyLoginByEmailAsync(LoginEmailDTO dto);
        Task<string?> UpdateCompanyAsync(int id, CompanyPutDTO request);
        Task<string?> DeleteCompanyAsync(int id);

    }
}
