using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.DTOs
{
    public class MessageDTO
    {
         public int Id { get; set; }   
         public int SenderId { get; set; }
        public required string SendUser { get; set; }
        public int RecipientId { get; set; }
        public required string RecipientUser { get; set; }
        public required string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.UtcNow;
    }
}