using Azure.Core;
using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;
using TechTitansAPI.SecurityServices;

namespace TechTitansAPI.Services.AppUser
{
    public class AppUserService : IAppUserService
    {
        private readonly DataContext _context;
        private readonly ISecurityService _securityService;

        public AppUserService(DataContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<AppUserModel?> GetUserAsync(int id)
        {
            var user = await _context.AppUsers
                .Where(u => u.Id == id)
                .Include(u => u.Trees)
                .ThenInclude(t => t.Pictures)
                .Select(u => new AppUserModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Cpf = u.Cpf,
					Email = u.Email,
                    Trees = u.Trees.Select(t => new TreeModel
                    {
                        AbsorbedCo2 = t.AbsorbedCo2,
                        CommonName = t.CommonName,
                        Id = t.Id,
                        AppUser = t.AppUser,
                        ScientificName = t.ScientificName,
                        TreeExtinctionIndex = t.TreeExtinctionIndex,
                        UserId = t.UserId,
                        Zoochory = t.Zoochory,
                        Pictures = t.Pictures.Select(p => new PictureModel
                        {
                            Id = p.Id,
                            Image = p.Image,
                            TreeId = p.TreeId
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();

            return user;
        }

		public async Task<List<TreeDTO>?> GetTreesByUserIdAsync(int id)
		{
			var trees = await _context.Trees
				.Where(t => t.UserId == id)
				.Include(t => t.Pictures)
				.Select(t => new TreeDTO
				{
					ScientificName = t.ScientificName,
					CommonName = t.CommonName,
					TreeExtinctionIndex = t.TreeExtinctionIndex,
					Zoochory = t.Zoochory,
					AbsorbedCo2 = t.AbsorbedCo2,
					OwnerCPF = t.AppUser.Cpf
				}).ToListAsync();
			return trees;
		}


        public async Task<string> RegisterUserAsync(AppUserDTO dto)
        {
            try
            {

            _securityService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var userModel = new AppUserModel
                {
                    Name = dto.Name,
                    Cpf = dto.Cpf,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                await _context.AppUsers.AddAsync(userModel);
                await _context.SaveChangesAsync();

                return ("registred");
            }
            catch (DbUpdateException ex)
            {
                // Examine a exceção interna para obter detalhes específicos do erro
                Exception innerException = ex.InnerException;
                if (innerException != null)
                {
                    return("Inner Exception: " + innerException.Message);
                    
                }
                return innerException.Message;
            }
        }


        public async Task<string> UserLoginByCPFAsync(LoginCPFDTO dto)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Cpf.ToLower().Equals(dto.Cpf.ToLower()));
            if (user == null) return null;
            if (!_securityService.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }

        public async Task<string> UserLoginByEmailAsync(LoginEmailDTO dto)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(dto.Email.ToLower()));
            if (user == null) return null;
            if (!_securityService.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt)) return ("wrong password");
            return "access allowed";
        }


        public async Task<string?> UpdateUserAsync(AppUserUpdateDTO dto, int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(t => t.Id == id);
            if (user == null) return null;
            if (!_securityService.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt)) return ("access denied");
             
            

            var trees = await _context.Trees.Where(t => dto.TreeIDs.Contains(t.Id)).ToListAsync();

            if (trees.Any()) { user.Trees.AddRange(trees); }
            user.Cpf = dto.Cpf;
            user.Name = dto.Name;
            _securityService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();
            return "updated";

        }


        public async Task<string?> DeleteUserAsync(int id)
		{
			var user = await _context.AppUsers.FindAsync(id);
			if (user == null)
			{
				return null;
			}
			_context.AppUsers.Remove(user);
			await _context.SaveChangesAsync();
			return "deleted";
		}

        
    }
}
