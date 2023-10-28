namespace UserAPI.DTOs
{
    public class AppUserUpdateDTO
    {
        public string Cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public List<int> TreeIDs { get; set; }
    }
}
