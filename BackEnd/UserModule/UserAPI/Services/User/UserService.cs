using System.Text.Json;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using UserAPI.DTOs;

namespace UserAPI.Services.User
{
    public class UserService : IUserService
    {
        readonly string urlApiBanco = "https://localhost:7122/api/AppUser/";



        public async Task<string> GetTreesByUserIdHTTPAsync(int id)
        {
            using var HttpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"{urlApiBanco}Tree/{id}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string?> GetUserHTTP(int id)
        {
            using var HttpClient = new HttpClient();

            HttpResponseMessage response = await HttpClient.GetAsync($"{urlApiBanco}user/{id}");

            return await response.Content.ReadAsStringAsync();



        }

        public async Task<string> RegisterUserHTTP(AppUserDTO dto)
        {
            using var HttpClient = new HttpClient();
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PostAsync(urlApiBanco, content);


                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateUserHTTP(AppUserUpdateDTO dto, int id)
        {
            using var HttpClient = new HttpClient();
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PutAsJsonAsync($"{urlApiBanco}update/{id}", dto);


                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteUserHTTPAsync(int id)
        {
            using var HttpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"{urlApiBanco}delete/{id}");

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
