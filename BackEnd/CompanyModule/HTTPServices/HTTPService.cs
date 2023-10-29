
using Microsoft.JSInterop.Infrastructure;
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
        readonly string urlEmail = "https://modulo-email:80/api/email"; //Refenciar o container de email exposto na 80
       
        private readonly string _urlAPI = "http://modulodb:80/api/Company/";//Isso serve para entrar no container 
        //chamado modulodb, que é o do banco de dados, se for usar localhost vai dar pau pq localmente no docker, 
        //não há nada na porta 5008 - por isso é necessário entrar no container gerado na porta correta e fazer o 
        //acesso (note que utilizamos  a porta 80 para isso e nao a 5008 pois a 5008 está exposta no localhost 
        //para entrar no container) 

        public HTTPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyGetDTO> GetCompanyByIdHTTP(int id)
        {

            string urlAPI = $"{_urlAPI}{id}";
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
                {
                    var emailContent = new
                    {
                        to = dto.Email, 
                        subject = "Bem-vindo ao Nosso Aplicativo",
                        body = "Olá, obrigado por se registrar em nosso aplicativo. Bem-vindo(a)!"
                    };

                    string emailJsonContent = JsonSerializer.Serialize(emailContent);
                    var emailBody = new StringContent(emailJsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage emailResponse = await _httpClient.PostAsync(urlEmail, emailBody);

                    if (emailResponse.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return "Empresa registrada com sucesso, mas houve um problema ao enviar o email de boas-vindas.";
                    }
                }
                else
                {
                    return null;
                }
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
                    var emailContent = new
                    {
                        to = dto.Email,
                        subject = "Atualização de Dados da Empresa",
                        body = "As informações da sua empresa foram atualizadas com sucesso."
                    };

                    string emailJsonContent = JsonSerializer.Serialize(emailContent);
                    var emailBody = new StringContent(emailJsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage emailResponse = await _httpClient.PostAsync(urlEmail, emailBody);

                    if (emailResponse.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return "Empresa atualizada com sucesso, mas houve um problema ao enviar o email de confirmação.";
                    }
                }
                else if ((int)response.StatusCode == 404)
                {
                    return "Empresa não encontrada";
                }
                return "error";

            }
            catch(Exception ex)
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
