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
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TreeDTO>?> GetTreesByUserIdHTTPAsync(int id)
        {
            using var HttpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"{urlApiBanco}Tree/{id}");
                string responseBody = await response.Content.ReadAsStringAsync();
                var treeList = JsonSerializer.Deserialize<List<TreeDTO>>(responseBody);
                return treeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AppUserGetDTO> GetUserHTTP(int id)
        {
            
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{urlApiBanco}user/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var userModel = JsonSerializer.Deserialize<AppUserGetDTO>(responseBody);

                    return userModel;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<string> RegisterUserHTTP(AppUserDTO dto)
        {
            
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(urlApiBanco, content); 


                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateUserHTTP(AppUserUpdateDTO dto, int id)
        {
            
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{urlApiBanco}update/{id}", dto);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteUserHTTPAsync(int id)
        {
           
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{urlApiBanco}delete/{id}");

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
