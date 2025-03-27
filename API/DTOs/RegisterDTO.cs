using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Funcao { get; set; }
        public required string Foto { get; set; }
        public DateTime DateBirth { get; set; }
    }
}