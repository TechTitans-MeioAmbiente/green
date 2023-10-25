using TechTitansAPI.DTOs;

namespace TechTitansAPI.Services.Picture
{
	public interface IPictureService
	{
		Task<string?> AddPictureToTreeAsync(PictureDTO dto, int id);
	}
}
