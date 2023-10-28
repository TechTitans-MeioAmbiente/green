using TechTitansAPI.DTOs;

namespace UserAPI.Services.Picture
{
    public interface IPictureService
    {
        Task<string?> AddPictureToTreeHTTPAsync(PictureDTO dto, int id);
    }
}
