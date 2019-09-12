using Microsoft.Extensions.Options;
using MongoDB.Driver;
using bot.Models;
using System;
using System.Linq;

namespace bot.Repositories.Base
{
    public class BotContext : IBotContext
    {
        public IMongoDatabase Database { get; }

        public BotContext(IOptions<ServerConfig> config)
        {
            var mongoConfig = config.Value.Mongo;

            var client = new MongoClient(mongoConfig.ConnectionString);
            Database = client.GetDatabase(mongoConfig.Database);
        }

        public IMongoCollection<Bot> Bots => Database.GetCollection<Bot>("bot");

        public Bot Create(Bot bot)
        {
            Bots.InsertOne(bot);

            return bot;
        }

        public Bot GetBotById(Guid id)
        {
            return Bots.Find(x => x.id.Equals(id)).FirstOrDefault();
        }

        public void Update(Bot bot)
        {
            Bots.ReplaceOne(x => x.id == bot.id, bot, new UpdateOptions { IsUpsert = true });
        }

        public void Delete(Guid id)
        {
            Bots.DeleteOne(x => x.id.Equals(id));
        }
    }
}

