using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs.GetDTOs
{
    public class TreeGetDTO
    {
        public int Id { get; set; }
        public string ScientificName { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
        public int Zoochory { get; set; }
        public double AbsorbedCo2 { get; set; }

        public string Geolocation { get; set; } = string.Empty; 
        public int UserId { get; set; } = 0;


        public List<int> PicturesIds { get; set; }



    }
}
