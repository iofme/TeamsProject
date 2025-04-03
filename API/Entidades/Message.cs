using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entidades
{
    public class Message
    {
        public int Id { get; set; }   
        public required string SendUser { get; set; }
        public required string RecipientUser { get; set; }
        public required string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.UtcNow;



        public int SenderId { get; set; }
        public Usuario Sender { get; set; } = null!;
        public int RecipientId { get; set; }
        public Usuario Recipient { get; set; } = null!;
    }
}