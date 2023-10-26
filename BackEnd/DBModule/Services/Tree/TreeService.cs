using Microsoft.EntityFrameworkCore;

using TechTitansAPI.Data;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Tree
{
    public class TreeService : ITreeService
    {
        private readonly DataContext _context;

        public TreeService(DataContext context)
        {
            _context = context;
        }
        public async Task<TreeModel?> GetTreeAsync(int id)
        {
            var tree = await _context.Trees
                 .Where(t => t.Id == id)
                 .Select(t => new TreeModel
                 {
                     Id = t.Id,
                     AbsorbedCo2 = t.AbsorbedCo2,
                     CommonName = t.CommonName,
                     ScientificName = t.ScientificName,
                     UserId = t.UserId,
                     TreeExtinctionIndex = t.TreeExtinctionIndex,
                     Zoochory = t.Zoochory,
                     Pictures = t.Pictures,
                 }) 
                 .FirstOrDefaultAsync();
            if (tree is null) return null;
            return tree;
        }

        public async Task<string?> RegisterTreeAsync(TreeDTO dto)
        { 
            var ownerID = await _context.AppUsers
                .Where(o => o.Cpf == dto.OwnerCPF) 
                .Select(o => o.Id)
                .FirstOrDefaultAsync(); 
            if (ownerID == null) return null;

            var treeModel = new TreeModel
            {  
                UserId = ownerID,
                ScientificName = dto.ScientificName,
                CommonName = dto.CommonName,
                TreeExtinctionIndex = dto.TreeExtinctionIndex,
                Zoochory = dto.Zoochory,
                AbsorbedCo2 = dto.AbsorbedCo2
            };

            await _context.Trees.AddAsync(treeModel);
            await _context.SaveChangesAsync();
            return ("registred");
        }

        public async Task<string?> UpdateTreeAsync(TreeUpdateDTO dto, int id)
        { 
            var tree = await _context.Trees.FirstOrDefaultAsync(x => x.Id== id);
            if (tree is null) return null; 
             
            var pictures = await _context.Pictures.Where(x => dto.PictureIDs.Contains(x.Id)).ToListAsync(); 
             
            if (pictures.Any()) tree.Pictures.AddRange(pictures);
            tree.ScientificName = dto.ScientificName; 
            tree.CommonName = dto.CommonName; 
            tree.Zoochory = dto.Zoochory;
            tree.AbsorbedCo2 = dto.AbsorbedCo2;
            tree.TreeExtinctionIndex= dto.TreeExtinctionIndex; 
             
            await _context.SaveChangesAsync();
            return "updated";

        }

        public async Task<string?> DeleteTreeAsync(int id)
        {
            var tree = await _context.Trees.FindAsync(id);
            if (tree is null)
            {
                return null;
            }
            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();
            return "deleted";

        }

		
	}
}
