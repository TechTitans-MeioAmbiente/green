using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs.GetDTOs
{
    public class AppUserGetDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<int> TreesIds { get; set; }
    }
}
