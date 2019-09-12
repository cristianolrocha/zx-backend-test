using Microsoft.Extensions.Options;
using MongoDB.Driver;
using bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bot.Repositories.Base
{
    public class MessageContext : IMessageContext
    {
        public IMongoDatabase Database { get; }

        public MessageContext(IOptions<ServerConfig> config)
        {
            var mongoConfig = config.Value.Mongo;

            var client = new MongoClient(mongoConfig.ConnectionString);
            Database = client.GetDatabase(mongoConfig.Database);
        }

        public IMongoCollection<Message> Messages => Database.GetCollection<Message>("message");

        public Message Create(Message message)
        {
            Messages.InsertOne(message);

            return message;
        }

        public Message GetMessageById(Guid id)
        {
            return Messages.Find(x => x.id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Message> GetAllMessagesByConversationId(Guid conversationId)
        {
            var messages = Messages.Find(x => x.conversationId.Equals(conversationId));

            if (messages == null)
            {
                return Enumerable.Empty<Message>();
            }

            return messages.ToList();
        }
    }
}

