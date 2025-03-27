using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.DTOs
{
    public class ListaCardsDTO
    {
         public required string NomeLista { get; set; }
        public List<Card>? Cards { get; set; }
    }
}