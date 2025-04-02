using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Entidades
{
    public class Card
    {
        public int Id { get; set; }
        public required string Cardname { get; set; }
        public required string Descricao { get; set; }
        public DateTime CreateItem { get; set; } = DateTime.UtcNow;
        public required string Createby { get; set; }
        public DateTime Datafinal { get; set; }
        public int Prioridade { get; set; }
        [JsonIgnore]
        public ListaCards? ListaCards { get; set; }
    }
}