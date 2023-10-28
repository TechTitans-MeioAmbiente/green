using System.Text.Json.Serialization;
using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
    public class TreeGetDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("scientificName")]
        public string ScientificName { get; set; } = string.Empty;

        [JsonPropertyName("commonName")]
        public string CommonName { get; set; } = string.Empty;

        [JsonPropertyName("treeExtinctionIndex")]
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }

        [JsonPropertyName("zoochory")]
        public int Zoochory { get; set; }

        [JsonPropertyName("absorbedCo2")]
        public double AbsorbedCo2 { get; set; }

        [JsonPropertyName("geolocation")]

        public string Geolocation { get; set; } = string.Empty;

        [JsonPropertyName("userId")]
        public int UserId { get; set; } = 0;

        [JsonPropertyName("picturesIds")]
        public List<int> PicturesIds { get; set; }



    }
}
