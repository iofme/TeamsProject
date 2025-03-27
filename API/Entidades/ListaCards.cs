using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entidades
{
    public class ListaCards
    {
        public int Id { get; set; }
        public required string NomeLista { get; set; }
        public List<Card>? Cards { get; set; }
    }
}