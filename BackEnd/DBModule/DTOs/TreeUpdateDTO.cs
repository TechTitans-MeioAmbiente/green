using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
	public class TreeUpdateDTO
	{
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
        public int Zoochory { get; set; }
        public double AbsorbedCo2 { get; set; } 
        public List<int> PictureIDs { get; set; }
    }
}
