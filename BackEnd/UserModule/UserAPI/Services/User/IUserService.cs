using TechTitansAPI.DTOs;
using TechTitansAPI.Models;
using UserAPI.DTOs;

namespace UserAPI.Services.User
{
    public interface IUserService
    {
        Task<AppUserGetDTO> GetUserHTTP(int id);
        Task<List<TreeDTO>?> GetTreesByUserIdHTTPAsync(int id);
        Task<string> RegisterUserHTTP(AppUserDTO dto);
        Task<string> UpdateUserHTTP(AppUserUpdateDTO dto, int id);
        Task<string> DeleteUserHTTPAsync(int id);


    }
}
