
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.GetDTOs;
using TechTitansAPI.DTOs.PutDTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace CompanyModule.HTTPServices
{
    public class HTTPService : IHTTPService
    {
        private readonly HttpClient _httpClient;
       
        private readonly string _urlAPI = "https://localhost:7122/api/Company/";

        public HTTPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyGetDTO> GetCompanyByIdHTTP(int id)
        {

            string urlAPI = $"{_urlAPI}company/{id}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(urlAPI);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var companyModel = JsonSerializer.Deserialize<CompanyGetDTO>(responseBody);

                    return companyModel;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> RegisterCompanyHTTP(CompanyDTO dto)
        {
            var urlAPI = _urlAPI; 
            try
            {
                
                string jsonContent = JsonSerializer.Serialize(dto);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(urlAPI, content);

                if (response.IsSuccessStatusCode) 
                    return await response.Content.ReadAsStringAsync();
                else 
                    return null;
            } 
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> UpdateCompanyByIdHTTP(CompanyPutDTO dto, int id)
        {
            var urlAPI = $"{_urlAPI}{id}";
            try
            {

                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(urlAPI, content);

                if (response.IsSuccessStatusCode)
                {
                     return await response.Content.ReadAsStringAsync();
                }
                else if ((int)response.StatusCode == 404)
                {
                    return "Company not found";
                }
                return "error";
                

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteCompanyByIdHTTP(int id)
        {
            var urlAPI = $"{_urlAPI}{id}";
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(urlAPI); 
                string responseText = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) return responseText;
                else if ((int)response.StatusCode == 404) return "Company not found"; 
                else if ((int)response.StatusCode == 400) return "Error";
                return responseText;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public async Task<string> CompanyLoginByCNPJHTTP(LoginCNPJDTO dto)
        {
            var urlAPI = $"{_urlAPI}login-cnpj";

            try
            {

                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(urlAPI, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    return "authentication failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> CompanyLoginByEmailHTTP(LoginEmailDTO dto)
        {
            var urlAPI = $"{_urlAPI}login-email";

            try
            {
                
                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(urlAPI, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                else
                {
                    return "authentication failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
