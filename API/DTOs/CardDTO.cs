
using API.Entidades;

namespace API.DTOs
{
    public class CardDTO
    {
        public required string Cardname { get; set; }
        public required string Descricao { get; set; }
        public DateTime CreateItem { get; set; } = DateTime.UtcNow;
        public DateTime Datafinal { get; set; }
        public int Prioridade { get; set; }
        public required int ListaCardsId { get; set; }
    }
}