using bot.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Services
{
    public interface IMessageService
    {
        Task<Message> CreateMessage(Message message, CancellationToken cancellationToken);
        Task<Message> GetMessageById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Message>> GetAllMessagesByConversationId(Guid ConversationId, CancellationToken cancellationToken);
    }
}
