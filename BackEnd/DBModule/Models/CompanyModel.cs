﻿namespace TechTitansAPI.Models
{
	public class CompanyModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
		public double EmitedCo2 { get; set; }
		public string Cnpj { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
    }
}
