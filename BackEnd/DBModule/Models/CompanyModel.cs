namespace TechTitansAPI.Models
{
	public class CompanyModel
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public string? Email { get; set; }
		public double EmitedCo2 { get; set; }
		public string Cnpj { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
