using bot.Models;
using bot.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMessageContext _context;

        public MessageRepository(IMessageContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessage(Message message, CancellationToken cancellationToken) => _context.Create(message);

        public async Task<Message> GetMessageById(Guid id, CancellationToken cancellationToken) => _context.GetMessageById(id);

        public async Task<IEnumerable<Message>> GetAllMessagesByConversationId(Guid conversationId, CancellationToken cancellationToken) => _context.GetAllMessagesByConversationId(conversationId);
    }
}
