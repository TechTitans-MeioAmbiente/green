using System.Text.Json.Serialization;

namespace TechTitansAPI.DTOs.GetDTOs
{
    public class CompanyGetDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("emitedCo2")]
        public double EmitedCo2 { get; set; } 

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } = string.Empty;


    }
}
