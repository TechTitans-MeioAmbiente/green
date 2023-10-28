namespace TechTitansAPI.Models
{
	public enum TreeExtinctionIndex
	{
		CR, EN, VU, NT, LC, DD, NE, NA
	}
	public class TreeModel
	{
		public int Id { get; set; }
		public string ScientificName { get; set; } = string.Empty;
		public string CommonName { get; set; } = string.Empty;
		public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
		public int Zoochory { get; set; }
		public double AbsorbedCo2 { get; set; }

		public string Geolocation { get; set; } = string.Empty;


        public int UserId { get; set; }

		public AppUserModel AppUser { get; set; }

		public List<PictureModel> Pictures { get; set; }
	}
}
