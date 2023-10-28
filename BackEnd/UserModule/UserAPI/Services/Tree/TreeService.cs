using System.Text;
using System.Text.Json;
using TechTitansAPI.DTOs;
using TechTitansAPI.Models;

namespace UserAPI.Services.Tree
{
    public class TreeService : ITreeService
    { 
        private readonly HttpClient _httpClient; 
        private readonly string _urlAPI = "https://localhost:7122/api/Tree/";

        public TreeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TreeGetDTO?> GetTreeHTTPAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_urlAPI}tree/{id}"); 
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var treeModel = JsonSerializer.Deserialize<TreeGetDTO>(responseBody);

                    return treeModel;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> RegisterTreeHTTPAsync(TreeDTO dto)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_urlAPI, content);

                if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
                else return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string?> UpdateTreeByIdHTTPAsync(TreeUpdateDTO dto, int id)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_urlAPI}update/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string?> DeleteTreeByIdHTTPAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_urlAPI}{id}");
                if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
                else return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
       
        
    }
}
