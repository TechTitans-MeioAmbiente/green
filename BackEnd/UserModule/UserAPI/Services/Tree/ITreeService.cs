using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace UserAPI.Services.Tree
{
    public interface ITreeService
    {
        Task<TreeGetDTO?> GetTreeHTTPAsync(int id);
        Task<string> RegisterTreeHTTPAsync(TreeDTO dto);
        Task<string?> UpdateTreeByIdHTTPAsync(TreeUpdateDTO dto, int id);
        Task<string?> DeleteTreeByIdHTTPAsync(int id);
    }
}
