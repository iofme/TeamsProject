using API.DTOs;
using API.Entidades;
using API.Extensions;
using API.Helpers;
using API.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController(IMessageRepository messageRepository, IUsuarioRepository usuarioRepository, IMapper mapper
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<MessageDTO>> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var user = User.GetUsername();
            if (user == createMessageDTO.RecipientUser.ToLower())
            {
                return BadRequest("You cannot message yourself");
            }

            var sender = await usuarioRepository.GetUsuarioByUsername(user);
            var recipient = await usuarioRepository.GetUsuarioByUsername(createMessageDTO.RecipientUser);

            if (recipient == null || sender == null)
            {
                return BadRequest("Cannot send message at this time");
            }

            var message = new Message
            {
                Content = createMessageDTO.Content,
                RecipientUser = recipient.Username,
                SendUser = sender.Username,
                Recipient = recipient,
                Sender = sender,
            };

            messageRepository.AddMessage(message);

            if (await messageRepository.SaveAllAsync()) return Ok(mapper.Map<MessageDTO>(message));

            return BadRequest("Failed to save message");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessagesForUser([FromQuery] MessageParams messageParams)
        {
            messageParams.Username = User.GetUsername();

            var messages = await messageRepository.GetMessagesForUser(messageParams);

            Response.AddPaginationHeader(messages);

            return messages;
        }

        [HttpGet("thread/{username}")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessageThread(string username)
        {
            var currentUsername = User.GetUsername();

            return Ok(await messageRepository.GetMessageThread(currentUsername, username));
        }
    }
}