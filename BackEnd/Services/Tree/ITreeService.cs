using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.Tree
{
    public interface ITreeService
    {
        Task<string?> RegisterTreeAsync(TreeDTO dto);
        Task<TreeModel?> GetTreeAsync(int id);
        Task<string?> DeleteTreeAsync(int id);
        Task<string?> UpdateTreeAsync(TreeUpdateDTO dto, int id);
    }
}
