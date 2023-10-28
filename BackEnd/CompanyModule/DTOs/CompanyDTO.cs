using System.Text.Json.Serialization;
namespace TechTitansAPI.DTOs
{
	public class CompanyDTO
	{
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;


    }
}
