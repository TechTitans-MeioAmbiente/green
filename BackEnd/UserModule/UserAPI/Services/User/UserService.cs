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
        readonly string urlApiBanco = "http://modulodb:80/api/AppUser/";//Isso serve para entrar no container 
        //chamado modulodb, que é o do banco de dados, se for usar localhost vai dar pau pq localmente no docker, 
        //não há nada na porta 5008 - por isso é necessário entrar no container gerado na porta correta e fazer o 
        //acesso (note que utilizamos  a porta 80 para isso e nao a 5008 pois a 5008 está exposta no localhost 
        //para entrar no container) 



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
