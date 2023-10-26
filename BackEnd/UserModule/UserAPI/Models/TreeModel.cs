using System.Text.Json.Serialization;
namespace TechTitansAPI.Models
{
	public enum TreeExtinctionIndex
	{
		CR, EN, VU, NT, LC, DD, NE, NA
	}
	public class TreeModel
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("scientificName")]
        public string ScientificName { get; set; }

        [JsonPropertyName("commonName")]
        public string CommonName { get; set; }

        [JsonPropertyName("treeExtinctionIndex")]
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }

        [JsonPropertyName("zoochory")]
        public int Zoochory { get; set; }

        [JsonPropertyName("absorbedCo2")]
        public double AbsorbedCo2 { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("appUser")]
        public AppUserModel AppUser { get; set; }
	}
}
