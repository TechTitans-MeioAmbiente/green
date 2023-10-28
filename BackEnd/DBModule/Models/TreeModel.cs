namespace TechTitansAPI.Models
{
	public enum TreeExtinctionIndex
	{
		CR, EN, VU, NT, LC, DD, NE, NA
	}
	public class TreeModel
	{
		public int Id { get; set; }
		public string ScientificName { get; set; }
		public string CommonName { get; set; }
		public TreeExtinctionIndex TreeExtinctionIndex { get; set; }
		public int Zoochory { get; set; }
		public double AbsorbedCo2 { get; set; }

		public string Geolocation { get; set; }


        public int UserId { get; set; }

		public AppUserModel AppUser { get; set; }

		public List<PictureModel> Pictures { get; set; }
	}
}
