namespace TechTitansAPI.Models
{
	public class AppUserModel
	{
		public int Id { get; set; } 
		public string? Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Cpf { get; set; }
		public string Name { get; set; }
		public List<TreeModel> Trees { get; set; } 
		  
		
	}
}
