using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
    public class TreeGetDTO
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
        public int Zoochory { get; set; }
        public double AbsorbedCo2 { get; set; }

        public string Geolocation { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;


        public List<int> Pictures { get; set; }



    }
}
