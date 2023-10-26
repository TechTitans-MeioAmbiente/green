using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.AppUser
{
    public interface IAppUserService
    {
        Task<string> RegisterUserAsync(AppUserDTO dto);
        Task<AppUserModel?> GetUserAsync(int id);
		Task<List<TreeDTO>?> GetTreesByUserIdAsync (int id);
        Task<string> UpdateUserAsync(AppUserUpdateDTO dto, int id);
        Task<string?> DeleteUserAsync(int id); 
    }
}
