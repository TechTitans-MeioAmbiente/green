namespace TechTitansAPI.Models
{
	public class AppUserModel
	{
		public int Id { get; set; } 
		public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Cpf { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public List<TreeModel> Trees { get; set; } 
		  
		
	}
}
