using bot.Models;
using bot.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> CreateMessage(Message message, CancellationToken cancellationToken) => await _messageRepository.CreateMessage(message, cancellationToken);

        public async Task<Message> GetMessageById(Guid id, CancellationToken cancellationToken) => await _messageRepository.GetMessageById(id, cancellationToken);

        public async Task<IEnumerable<Message>> GetAllMessagesByConversationId(Guid conversationId, CancellationToken cancellationToken) => await _messageRepository.GetAllMessagesByConversationId(conversationId, cancellationToken);
    }
}
