namespace UserAPI.DTOs
{
    public class AppUserUpdateDTO
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<int> TreeIDs { get; set; }
    }
}
