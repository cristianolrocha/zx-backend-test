using bot.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(Message message, CancellationToken cancellationToken);
        Task<Message> GetMessageById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Message>> GetAllMessagesByConversationId(Guid conversationId, CancellationToken cancellationToken);
    }
}
