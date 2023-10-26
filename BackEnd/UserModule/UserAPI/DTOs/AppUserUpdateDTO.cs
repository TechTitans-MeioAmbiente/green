namespace UserAPI.DTOs
{
    public class AppUserUpdateDTO
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public List<int> TreeIDs { get; set; }
    }
}
