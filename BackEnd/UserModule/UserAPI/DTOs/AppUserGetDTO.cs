using System.Text.Json.Serialization;
using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
    public class AppUserGetDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("treesIds")]
        public List<int> TreesIds { get; set; }
    }
}
