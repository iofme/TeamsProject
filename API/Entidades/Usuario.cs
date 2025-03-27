using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Funcao { get; set; }
        public required string Foto { get; set; }
        public DateTime DateBirth { get; set; }

        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswoedSalt { get; set; }
    }
}