using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.AppUser
{
    public interface IAppUserService
    {
        Task<AppUserGetDTO?> GetUserAsync(int id);
		Task<List<TreeDTO>?> GetTreesByUserIdAsync (int id);
        Task<string> RegisterUserAsync(AppUserDTO dto);
        Task<string> UserLoginByCPFAsync(LoginCPFDTO dto);
        Task<string> UserLoginByEmailAsync(LoginEmailDTO dto);
        Task<string> UpdateUserAsync(AppUserUpdateDTO dto, int id);
        Task<string?> DeleteUserAsync(int id); 
    }
}
