using System.Text.Json.Serialization;
namespace TechTitansAPI.DTOs
{
	public class CompanyDTO
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        
    }
}
