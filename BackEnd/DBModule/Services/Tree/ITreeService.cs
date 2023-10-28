using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Tree
{
    public interface ITreeService
    {
        Task<TreeGetDTO?> GetTreeAsync(int id);
        Task<string?> RegisterTreeAsync(TreeDTO dto);
        Task<string?> UpdateTreeAsync(TreeUpdateDTO dto, int id);
        Task<string?> DeleteTreeAsync(int id);
    }
}
