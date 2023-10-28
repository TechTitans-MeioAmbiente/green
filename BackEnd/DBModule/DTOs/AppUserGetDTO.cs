﻿using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
    public class AppUserGetDTO
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public List<int> TreesIds { get; set; }
    }
}
