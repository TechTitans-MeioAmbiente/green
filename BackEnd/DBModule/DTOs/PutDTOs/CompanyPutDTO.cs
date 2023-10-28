namespace TechTitansAPI.DTOs.PutDTOs
{
    public class CompanyPutDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public double EmitedCo2 { get; set; } // #atualizado
    }
}
