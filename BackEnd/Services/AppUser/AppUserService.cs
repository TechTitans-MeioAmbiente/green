﻿using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.AppUser
{
    public class AppUserService : IAppUserService
    {
        private readonly DataContext _context;

        public AppUserService(DataContext context)
        {
            _context = context;
        }

		public async Task<string> RegisterUserAsync(AppUserDTO dto)
		{
			var userModel = new AppUserModel
			{
				Name = dto.Name,
				Cpf = dto.Cpf,
			};
			await _context.AppUsers.AddAsync(userModel);
			await _context.SaveChangesAsync();
			return ("registred");
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

		public async Task<string?> UpdateUserAsync(AppUserUpdateDTO dto, int id)
		{
			var user = await _context.AppUsers.FirstOrDefaultAsync(t => t.Id == id);
			if (user == null) return null;

            var trees = await _context.Trees.Where(t => dto.TreeIDs.Contains(t.Id)).ToListAsync();
			 
			user.Trees.AddRange(trees); 
			user.Cpf = dto.Cpf; 
			user.Name = dto.Name;
			 
			await _context.SaveChangesAsync();
			return "updated";

        }
		
	}
}
