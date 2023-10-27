using Azure.Core;
using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
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

        public async Task<CompanyModel?> GetCompanyAsync(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
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
                PasswordSalt = passwordSalt
        };
            await _context.Companies.AddAsync(companyModel);
            await _context.SaveChangesAsync();
            return "registred";
        }

        public async Task<string> CompanyLoginByCNPJAsync(string cnpj, string password)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Cnpj.ToLower().Equals(cnpj.ToLower()));
            if (company == null) return null;
            if (!_securityService.VerifyPasswordHash(password, company.PasswordHash, company.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }

        public async Task<string> CompanyLoginByEmailAsync(string email, string password)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (company == null) return null;
            if (!_securityService.VerifyPasswordHash(password, company.PasswordHash, company.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }

        public async Task<string?> UpdateCompanyAsync(int id, CompanyDTO request)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            if (!_securityService.VerifyPasswordHash(request.Password, company.PasswordHash, company.PasswordSalt)) return ("access denied");

            company.Cnpj = request.Cnpj;
            company.Name = request.Name;
            company.Email = request.Email;
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
