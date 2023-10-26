using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;

        public CompanyService(DataContext context)
        {
            _context = context;
        }

        public async Task<CompanyModel?> GetCompanyAsync(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (company == null) return null;
            return company;
        }

        public async Task<string> RegisterCompanyAsync(CompanyDTO dto)
        {
            var companyModel = new CompanyModel
            {
                Cnpj = dto.Cnpj,
                Name = dto.Name,
            };
            await _context.Companies.AddAsync(companyModel);
            await _context.SaveChangesAsync();
            return "registred";
        }
        public async Task<CompanyModel?> UpdateCompanyAsync(int id, CompanyDTO request)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            company.Cnpj = request.Cnpj;
            company.Name = request.Name;
            company.Email = request.Email;


            await _context.SaveChangesAsync();

            return company;
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
