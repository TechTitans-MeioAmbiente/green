namespace TechTitansAPI.Models
{
	public class PictureModel
	{
		public int Id { get; set; }
		public byte[] Image { get; set; }

		public TreeModel Tree { get; set; } 
		 
		public int TreeId { get; set; }
	}
}
