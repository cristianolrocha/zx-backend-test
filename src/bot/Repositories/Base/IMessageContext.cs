using MongoDB.Driver;
using bot.Models;
using System;
using System.Collections.Generic;

namespace bot.Repositories.Base
{
    public interface IMessageContext
    {
        IMongoDatabase Database { get; }

        Message Create(Message message);
        Message GetMessageById(Guid id);
        IEnumerable<Message> GetAllMessagesByConversationId(Guid conversationId);
    }
}
