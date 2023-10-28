﻿using System.Text.Json;
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


        readonly string urlEmail = "https://modulo-email:80/api/email"; //Aqui precisa referenciar o container do e-mail (Exposto na porta 80)

        private readonly HttpClient _httpClient;

        readonly string urlApiBanco = "http://modulodb:80/api/AppUser/";//Isso serve para entrar no container 
        //chamado modulodb, que é o do banco de dados, se for usar localhost vai dar pau pq localmente no docker, 
        //não há nada na porta 5008 - por isso é necessário entrar no container gerado na porta correta e fazer o 
        //acesso (note que utilizamos  a porta 80 para isso e nao a 5008 pois a 5008 está exposta no localhost 
        //para entrar no container) 

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

                if (response.IsSuccessStatusCode)
                {
                    var emailContent = new
                    {
                        to = dto.Email,
                        subject = $"Bem-vindo ao Nosso Aplicativo {dto.Name}",
                        body = "Olá, obrigado por se registrar no nosso aplicativo. Bem-vindo(a)!"
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
                        return "Usuário registrado com sucesso, mas houve um problema ao enviar o email de boas-vindas.";
                    }
                }
                else
                {
                    return "Houve um erro no registro do usuário.";
                }
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

                if (response.IsSuccessStatusCode)
                {
                    var emailContent = new
                    {
                        to = dto.Email,
                        subject = "Atualização de Dados",
                        body = "Suas informações de usuário foram atualizadas com sucesso."
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
                        return "Usuário atualizado com sucesso, mas houve um problema ao enviar o email de confirmação.";
                    }
                }
                else
                {
                    return "Houve um erro na atualização do usuário.";
                }
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
