using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace TechTitansAPI.Services.AppUser
{
    public interface IAppUserService
    {
        Task<AppUserModel?> GetUserAsync(int id);
		Task<List<TreeDTO>?> GetTreesByUserIdAsync (int id);
        Task<string> RegisterUserAsync(AppUserDTO dto);
        Task<string> UserLoginByCPFAsync(string cpf, string password);
        Task<string> UserLoginByEmailAsync(string email, string password);
        Task<string> UpdateUserAsync(AppUserUpdateDTO dto, int id);
        Task<string?> DeleteUserAsync(int id); 
    }
}
