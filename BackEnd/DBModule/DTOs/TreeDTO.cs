using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
	public class TreeDTO
	{
		public string ScientificName { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
		public int Zoochory { get; set; }
		public double AbsorbedCo2 { get; set; }
		public string OwnerCPF { get; set; } = string.Empty;
    }
}
