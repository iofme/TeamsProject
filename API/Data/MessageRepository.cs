using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entidades;
using API.Helpers;
using API.Interface;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class MessageRepository(DataContext context, IMapper mapper) : IMessageRepository
    {
        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            context.Messages.Remove(message); 
        }

        public async Task<Message?> GetMessage(int id)
        {
            return await context.Messages.FindAsync(id);
        }

        public async Task<PagedList<MessageDTO>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = context.Messages
                .OrderByDescending(x => x.MessageSent)
                .AsQueryable();


            query = messageParams.Container switch
            {
                "Inbox" => query.Where(x => x.Recipient.Username == messageParams.Username),
                "Outbox" => query.Where(x => x.Sender.Username == messageParams.Username),
                _ => query.Where(x => x.Recipient.Username == messageParams.Username && x.DateRead == null)
            };

            var messages = query.ProjectTo<MessageDTO>(mapper.ConfigurationProvider);

            return await PagedList<MessageDTO>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public Task<IEnumerable<MessageDTO>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
           return await context.SaveChangesAsync() > 0;
        }
    }
}