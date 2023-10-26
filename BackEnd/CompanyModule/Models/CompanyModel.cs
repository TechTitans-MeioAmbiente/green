using System.Text.Json.Serialization;
namespace TechTitansAPI.Models
{
	public class CompanyModel
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("emitedCo2")]
        public double EmitedCo2 { get; set; }

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }
    }
}
