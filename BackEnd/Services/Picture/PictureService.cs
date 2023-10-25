using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Picture
{
	public class PictureService : IPictureService
	{

		private readonly DataContext _context;

		public PictureService(DataContext context)
		{
			_context = context;
		}

		public async Task<string?> AddPictureToTreeAsync(PictureDTO dto, int id)
		{
			var tree = await _context.Trees.FirstOrDefaultAsync(x => x.Id == id);
			if (tree == null) return null;
			var picture = new PictureModel
			{
				Image = dto.Image,
				TreeId = id,
				Tree = tree
			};
			await _context.Pictures.AddAsync(picture); 
			await _context.SaveChangesAsync();

			return "created";
		}
	}
}
