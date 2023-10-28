using System.Text.Json;
using System.Text;
using TechTitansAPI.DTOs;

namespace UserAPI.Services.Picture
{
    public class PictureService : IPictureService
    {
        private readonly HttpClient _httpClient;
        private readonly string urlAPI = "http://modulodb:80/api/Picture/";

        public PictureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> AddPictureToTreeHTTPAsync(PictureDTO dto, int id)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{urlAPI}post", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
