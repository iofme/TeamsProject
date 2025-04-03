using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateMessageDTO
    {
        public required string RecipientUser { get; set; }
        public required string Content { get; set; }
    }
}