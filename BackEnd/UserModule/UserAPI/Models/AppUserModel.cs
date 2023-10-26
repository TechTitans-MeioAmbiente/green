namespace TechTitansAPI.Models
{
	public class AppUserModel
	{
		public int Id { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
		public string Name { get; set; } 
		public List<TreeModel> Trees { get; set; }
	}
}
