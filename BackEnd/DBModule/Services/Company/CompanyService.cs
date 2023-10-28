using Azure.Core;
using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;
using TechTitansAPI.SecurityServices;

namespace TechTitansAPI.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;
        private readonly ISecurityService _securityService;

        public CompanyService(DataContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<CompanyGetDTO?> GetCompanyAsync(int id)
        {
            var company = await _context.Companies
                .Where(c => c.Id == id)
                .Select(c => new CompanyGetDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email, 
                    Cnpj = c.Cnpj, 
                    EmitedCo2 = c.EmitedCo2,
                })
                .FirstOrDefaultAsync();
            if (company == null) return null; 
            return company;
            
        }

        public async Task<string> RegisterCompanyAsync(CompanyDTO dto)
        { 
            _securityService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var companyModel = new CompanyModel
            {
                Cnpj = dto.Cnpj,
                Name = dto.Name, 
                PasswordHash = passwordHash, 
                PasswordSalt = passwordSalt,
                Email = dto.Email,

        };
            await _context.Companies.AddAsync(companyModel);
            await _context.SaveChangesAsync();
            return "registred";
        }

        public async Task<string> CompanyLoginByCNPJAsync(LoginCNPJDTO dto)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Cnpj.ToLower().Equals(dto.Cnpj.ToLower()));
            if (company == null) return null;
            if (!_securityService.VerifyPasswordHash(dto.Password, company.PasswordHash, company.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }

        public async Task<string> CompanyLoginByEmailAsync(LoginEmailDTO dto)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(dto.Email.ToLower()));
            if (company == null) return null;
            if (!_securityService.VerifyPasswordHash(dto.Password, company.PasswordHash, company.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }

        public async Task<string?> UpdateCompanyAsync(int id, CompanyPutDTO request)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            if (!_securityService.VerifyPasswordHash(request.Password, company.PasswordHash, company.PasswordSalt)) return ("access denied");

            company.Cnpj = request.Cnpj;
            company.Name = request.Name;
            company.Email = request.Email; 
            company.EmitedCo2 = request.EmitedCo2;
            _securityService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            company.PasswordHash = passwordHash;
            company.PasswordSalt = passwordSalt;


            await _context.SaveChangesAsync();

            return "updated";
        }

        public async Task<string?> DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return "deleted";

        }

        
    }
}
