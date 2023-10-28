
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TechTitansAPI.DTOs;
using TechTitansAPI.DTOs.SecurityDTOs;
using TechTitansAPI.Models;

namespace CompanyModule.HTTPServices
{
    public class HTTPService : IHTTPService
    {
        private readonly HttpClient _httpClient;
       
        private readonly string _urlAPI = "http://modulodb:80/api/Company/";//Isso serve para entrar no container 
        //chamado modulodb, que é o do banco de dados, se for usar localhost vai dar pau pq localmente no docker, 
        //não há nada na porta 5008 - por isso é necessário entrar no container gerado na porta correta e fazer o 
        //acesso (note que utilizamos  a porta 80 para isso e nao a 5008 pois a 5008 está exposta no localhost 
        //para entrar no container) 

        public HTTPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyModel> GetCompanyByIdHTTP(int id)
        {

            string urlAPI = $"{_urlAPI}company/{id}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(urlAPI);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var companyModel = JsonSerializer.Deserialize<CompanyModel>(responseBody);

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
        public async Task<CompanyModel> UpdateCompanyByIdHTTP(CompanyDTO dto, int id)
        {
            var urlAPI = $"{_urlAPI}{id}";
            try
            {

                string jsonContent = JsonSerializer.Serialize(dto);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(urlAPI, content);

                if (response.IsSuccessStatusCode)
                {
                    var updatedCompany = JsonSerializer.Deserialize<CompanyModel>(await response.Content.ReadAsStringAsync());
                    return updatedCompany;
                }
                else
                {
                    return null;
                }
                

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
                if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();
                else return null;
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
